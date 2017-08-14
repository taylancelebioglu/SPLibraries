using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Data;

namespace SharePoint.Libraries.Entity
{
    public class SiteRepositoryBase<T> where T : IEntity
    {
        private IViewFieldsBuilder fieldsBuilder;
        private EntityConverter<T> entityConverter;
        private SPWeb _Web;
        public SiteRepositoryBase(SPWeb web)
        {
            _Web = web;
            fieldsBuilder = ViewFieldsFactory.GetBuilder(typeof(T));
            entityConverter = new EntityConverter<T>(web);
        }

        /// <summary>
        /// SharePoint does not support including multi-value fields in the ViewFields property of SPSiteDataQuery object
        /// http://support.microsoft.com/kb/2703054
        /// </summary>
        /// <param name="siteDataQuery"><FieldRef Name='taxonomy1' Nullable='true' Type='TaxonomyFieldTypeMulti'/></param>
        /// <returns>No value for field types TaxonomyFieldTypeMulti, LookupMulti, UserMulti</returns>
        public IList<T> GetItems(SPSiteDataQuery siteDataQuery)
         {
            if (string.IsNullOrEmpty(siteDataQuery.ViewFields))
            {
                siteDataQuery.ViewFields = fieldsBuilder.GetViewFields(true);
                entityConverter.ViewFields = fieldsBuilder.Fields;
            }
            else
            {
                entityConverter.ViewFields = fieldsBuilder.ExtractViewFields(siteDataQuery.ViewFields);
            }

            DataTable results = _Web.GetSiteData(siteDataQuery);

            List<T> retVal = new List<T>();

            if (results != null && results.Rows.Count > 0)
            {
                DataRowCollection rows = results.Rows;
                foreach (DataRow row in rows)
                {
                    retVal.Add(entityConverter.ConvertToEntity(row));
                }
            }
            return retVal;
        }
    }
}