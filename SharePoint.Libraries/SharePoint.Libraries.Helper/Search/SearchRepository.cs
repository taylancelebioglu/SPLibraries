using Microsoft.SharePoint;

namespace SharePoint.Libraries.Helper.Search
{
    public class SearchRepository : SearchBaseRepository
    {
        SPSite site;
        public SearchRepository(SPSite site)
            : base(site)
        {
            this.site = site;
        }
        //public List<EmployeeSearchModel> GetEmployeesOfTheMount(int month = 0, int year = 0, int rowCount = 0)
        //{
        //    KeywordQuery keywordQuery = new KeywordQuery(site);

        //    StringBuilder queryBuilder = new StringBuilder();
        //    queryBuilder.Append("ContentType:EmployeesOfTheMonth");
        //    if (year > 0)
        //    {
        //        queryBuilder.Append(string.Format(" AND {0}={1}", Constant.Search.ManagedProperty.Year, year));
        //    }
        //    if (month > 0)
        //    {
        //        queryBuilder.Append(string.Format(" AND {0}={1}", Constant.Search.ManagedProperty.Month, month));
        //    }

        //    if (rowCount > 0)
        //    {
        //        keywordQuery.RowLimit = rowCount;
        //    }
        //    keywordQuery.QueryText = queryBuilder.ToString();
        //    keywordQuery.Refiners = string.Format("{0},{1}", Constant.Search.ManagedProperty.YearString, Constant.Search.ManagedProperty.MonthString);
        //    keywordQuery.EnableSorting = true;
        //    keywordQuery.SortList.Add(Constant.Search.ManagedProperty.Year, SortDirection.Descending);
        //    keywordQuery.SortList.Add(Constant.Search.ManagedProperty.Month, SortDirection.Descending);
        //    keywordQuery.EnableNicknames = true;
        //    keywordQuery.EnablePhonetic = true;
        //    keywordQuery.TrimDuplicates = false;

        //    return base.GetSearchResults<EmployeeSearchModel>(keywordQuery);
        //}
    }
}