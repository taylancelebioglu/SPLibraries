using System.Collections.Generic;

namespace SharePoint.Libraries.Entity
{
    internal static class InvalidFieldAdapterManager
    {
        private static readonly Dictionary<string, IFieldAdapter> invalidFieldAdapters = new Dictionary<string, IFieldAdapter>() 
                                                                                      {
                                                                                        { "Image", new PublishingPageImageAdapter() },
                                                                                        { "HTML", new PublishingPageContentAdapter() },
                                                                                        { "TaxonomyFieldValue", new TaxonomyAdapter() },
                                                                                        { "TaxonomyFieldValueCollection", new TaxonomyMultiAdapter() },
                                                                                        { "PublishingScheduleStartDateFieldType", new PublishingScheduleAdapter() },
                                                                                        { "PublishingScheduleEndDateFieldType", new PublishingScheduleAdapter() },
                                                                                        { "Default", new InvalidDefaultAdapter() }
                                                                                       };

        internal static IFieldAdapter GetAdapterFor(string typeAsString)
        {
            if (invalidFieldAdapters.ContainsKey(typeAsString))
            {
                return invalidFieldAdapters[typeAsString];
            }
            else
            {
                return invalidFieldAdapters["Default"];
            }
        }

        internal static IFieldAdapter GetAdapterFor(object propertyType)
        {
            return invalidFieldAdapters["Default"];
        }
    }
}