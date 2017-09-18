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
      
        // Methods should be added here
    }
}