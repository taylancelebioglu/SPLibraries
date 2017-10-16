using Microsoft.SharePoint;
using SharePoint.Libraries.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointTestConsole
{
    public class PageLibraryRepository : RepositoryBase<PageEntity>
    {
        private SPWeb _web;
        public PageLibraryRepository(SPWeb web) : base(web)
        {
            _web = web;
        }
        protected override string ListUrl => "Pages";
    }
}
