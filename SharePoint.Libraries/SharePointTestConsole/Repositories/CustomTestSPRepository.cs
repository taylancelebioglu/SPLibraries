using SharePoint.Libraries.Entity;
using Microsoft.SharePoint;

namespace SharePointTestConsole.Repositories
{
    /// <summary>
    /// If you want to work with list items, use SPRepositoryBase 
    /// </summary>
    public class CustomTestSPRepository : SPRepositoryBase
    {
        protected override string ListUrl => "Lists/CustomTestList";
        public CustomTestSPRepository(SPWeb web) : base(web)
        {
        }
        public SPListItemCollection GetItemsByOrder()
        {
            SPQuery orderQuery = new SPQuery();
            orderQuery.Query = "<OrderBy><FieldRef Name='DateTimeField' /></OrderBy>";
            return base.GetItems(orderQuery);
        }
    }
}