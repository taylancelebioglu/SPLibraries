using System;
using System.Collections.Generic;

namespace SharePoint.Libraries.Entity
{
    public interface IViewFieldsBuilder
    {
        List<String> Fields { get; set; }
        String GetViewFields();
        String GetViewFields(bool useSPSiteDataQuery);
        List<String> GetFields(String queryViewXml);
        List<String> ExtractViewFields(String fieldNodes);
    }
}