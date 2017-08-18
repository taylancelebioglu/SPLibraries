using System;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace SharePoint.Libraries.Helper.Search
{
    public abstract class SearchProxyBase
    {
        public SearchQueryAndSiteSettingsServiceProxy ServiceProxy { get; private set; }
        public SearchServiceApplicationProxy SearchApplicationProxy { get; private set; }
        public SPSite Site { get; private set; }

        public SearchProxyBase(SPSite site)
        {
            this.Site = site;
            this.ServiceProxy = SPFarm.Local.ServiceProxies.GetValue<SearchQueryAndSiteSettingsServiceProxy>();
            this.SearchApplicationProxy = SearchServiceApplicationProxy.GetProxy(SPServiceContext.GetContext(this.Site)) as SearchServiceApplicationProxy;
        }
        protected SearchProxyBase(String searchApplicationProxyName, SPSite site)
        {
            this.ServiceProxy = SPFarm.Local.ServiceProxies.GetValue<SearchQueryAndSiteSettingsServiceProxy>();
            this.SearchApplicationProxy = this.ServiceProxy.ApplicationProxies.GetValue<SearchServiceApplicationProxy>(searchApplicationProxyName);
        }
        protected SearchProxyBase(Guid searchApplicationProxyId, SPSite site)
        {
            this.ServiceProxy = SPFarm.Local.ServiceProxies.GetValue<SearchQueryAndSiteSettingsServiceProxy>();
            this.SearchApplicationProxy = this.ServiceProxy.ApplicationProxies.GetValue<SearchServiceApplicationProxy>(searchApplicationProxyId);
        }
    }
}