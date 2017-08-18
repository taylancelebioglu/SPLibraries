using SharePoint.Libraries.Entity;
using SharePointTestConsole.Entities;
using Microsoft.SharePoint;
using System.Collections.Generic;

namespace SharePointTestConsole.Repositories
{
    public class CustomTestEntityRepository : RepositoryBase<CustomTestEntity>
    {
        protected override string ListUrl => "Lists/CustomTestList";
        public CustomTestEntityRepository(SPWeb web) : base(web)
        {
        }

        /// <summary>
        /// You can easily pass your custom query to the base GetItems method. If you don't specify any view field, base repository is going to add view fields according to your entity.
        /// You don't need any custom method for Add/Update/Delete item, get allitems, getitembyId operations.
        /// </summary>
        /// <returns></returns>
        public IList<CustomTestEntity> GetItemsByOrder()
        {
            SPQuery orderQuery = new SPQuery();
            orderQuery.Query = "<OrderBy><FieldRef Name='DateTimeField' /></OrderBy>";
            return base.GetItems(orderQuery);
        }
    }
}