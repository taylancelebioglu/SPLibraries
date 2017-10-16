using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using SharePoint.Libraries.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointTestConsole
{
    public class PageEntity : EntityBase
    {
        [SPFieldFlag]
        public SPFieldUserValueCollection Employees { get; set; }
        [SPFieldFlag]
        public int WatchCount { get; set; }
        [SPFieldFlag]
        public TaxonomyFieldValueCollection VideoTags { get; set; }
        [SPFieldFlag]
        public SPFieldLookupValueCollection VideoChannels { get; set; }
    }
}