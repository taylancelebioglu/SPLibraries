using Microsoft.Office.Server.Search.Query;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SharePoint.Libraries.Helper.Search
{
    public class SearchBaseRepository
    {
        public List<RefinerModel> Refiners { get; set; }
        SearchProxy proxy;
        public SearchBaseRepository()
        {
            proxy = new SearchProxy(SPContext.Current.Site);
            Refiners = new List<RefinerModel>();
        }
        public SearchBaseRepository(SPSite site)
        {
            proxy = new SearchProxy(site);
        }
        internal List<T> GetSearchResults<T>(KeywordQuery query)
        {
            var model = System.Activator.CreateInstance<T>();
            if (query.SelectProperties.Count.Equals(0))
            {
                query.SelectProperties.AddRange(model.GetType().GetProperties().Select(p => p.Name).ToArray());
            }

            SearchExecutor searchExecutor = new SearchExecutor();
            ResultTableCollection resultTableCollection = searchExecutor.ExecuteQuery(query);
            var resultTables = resultTableCollection.Filter("TableType", KnownTableTypes.RelevantResults);
            var resultTable = resultTables.FirstOrDefault();
            DataTable dataTable = resultTable.Table;

            if (!string.IsNullOrEmpty(query.Refiners))
            {
                var refinementTables = resultTableCollection.Filter("TableType", KnownTableTypes.RefinementResults);
                var refinementTable = refinementTables.FirstOrDefault();
                if (refinementTable != null)
                {
                    Refiners = (from dataRow in refinementTable.Table.AsEnumerable()
                                select new RefinerModel()
                                        {
                                            RefinementCount = Convert.ToString(dataRow["RefinementCount"]),
                                            RefinementValue = Convert.ToString(dataRow["RefinementValue"]),
                                            RefinerName = Convert.ToString(dataRow["RefinerName"])
                                        }).ToList();
                }
            }
            var result = from dataRow in dataTable.AsEnumerable()
                         select GetModel<T>(dataRow);
            return result.ToList();
        }
        internal T GetSearchResult<T>(KeywordQuery query)
        {
            var model = System.Activator.CreateInstance<T>();
            if (query.SelectProperties.Count.Equals(0))
            {
                query.SelectProperties.AddRange(model.GetType().GetProperties().Select(p => p.Name).ToArray());
            }

            SearchExecutor searchExecutor = new SearchExecutor();
            ResultTableCollection resultTableCollection = searchExecutor.ExecuteQuery(query);
            var resultTables = resultTableCollection.Filter("TableType", KnownTableTypes.RelevantResults);
            var resultTable = resultTables.FirstOrDefault();
            DataTable dataTable = resultTable.Table;

            if (dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                var rowModel = GetModel<T>(dataTable.Rows[0]);
                return rowModel;
            }
            else
            {
                return default(T);
            }
        }
        internal DataTable GetDynamicSearchResults(KeywordQuery query)
        {
            SearchExecutor searchExecutor = new SearchExecutor();
            ResultTableCollection resultTableCollection = searchExecutor.ExecuteQuery(query);
            var resultTables = resultTableCollection.Filter("TableType", KnownTableTypes.RelevantResults);
            var resultTable = resultTables.FirstOrDefault();
            return resultTable.Table;
        }
        internal T GetModel<T>(DataRow dataRow)
        {
            var model = System.Activator.CreateInstance<T>();

            PropertyInfo[] properties = model.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                var attrSearch = propertyInfo.GetCustomAttribute(typeof(SearchIgnoreAttribute), false);
                if (attrSearch == null)
                {
                    var property = model.GetType().GetProperty(propertyInfo.Name);

                    if (dataRow[propertyInfo.Name] != null && !string.IsNullOrEmpty(Convert.ToString(dataRow[propertyInfo.Name])))
                    {
                        property.SetValue(model, dataRow[propertyInfo.Name], null);
                    }
                }
            }
            return model;
        }
    }
}