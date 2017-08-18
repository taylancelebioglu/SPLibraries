using Microsoft.Office.Server.Search.Query;
using Microsoft.SharePoint;
using System;
using System.Data;
using System.Linq;

namespace SharePoint.Libraries.Helper.Search
{
    internal class SearchService
    {
        SearchProxy proxy;

        public SearchService()
        {
            proxy = new SearchProxy(SPContext.Current.Site);
        }

        public SearchService(SPSite site)
        {
            proxy = new SearchProxy(site);
        }

        public DataTable ExecuteQuery(KeywordQuery query)
        {
            SearchExecutor searchExecutor = new SearchExecutor();
            ResultTableCollection resultTableCollection = searchExecutor.ExecuteQuery(query);
            var resultTables = resultTableCollection.Filter("TableType", KnownTableTypes.RelevantResults);
            Guid nullGuid = new Guid("00000000-0000-0000-0000-000000000000");
            ResultTable resultTable = resultTables.Where(q => q.QueryRuleId == nullGuid).FirstOrDefault();
            return resultTable.Table;
        }
    }
}