using SharePoint.Libraries.Entity;
using SharePointTestConsole.Entities;
using Microsoft.SharePoint;

namespace SharePointTestConsole.Repositories
{
    /// <summary>
    /// This repository is being used for quering by 'SPSiteDataQuery'
    /// </summary>
    public class CustomTestEntitySiteRepository : SiteRepositoryBase<CustomTestEntity>
    {
        public CustomTestEntitySiteRepository(SPWeb web) : base(web)
        {
        }
    }
}