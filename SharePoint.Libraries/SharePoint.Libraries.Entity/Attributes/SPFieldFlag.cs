using System;

namespace SharePoint.Libraries.Entity
{
    public class SPFieldFlag : Attribute
    {
        public String Name { get; set; }
        public Boolean RestrictUpdate { get; set; }
    }
}