using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using SharePoint.Libraries.Entity;
using System;

namespace SharePointTestConsole.Entities
{
    public class CustomTestEntity : EntityBase
    {
        [SPFieldFlag]
        public string ChoiceField { get; set; }
        [SPFieldFlag]
        public int NumberField { get; set; }
        /// <summary>
        /// can be givven a different name rather than sp field's internal name
        /// </summary>
        [SPFieldFlag(Name = "CurrencyField")]
        public double Currency { get; set; }
        [SPFieldFlag(RestrictUpdate = true)]
        public DateTime? DateTimeField { get; set; }
        [SPFieldFlag(Name = "YesNoField")]
        public bool BooleanField { get; set; }
        [SPFieldFlag]
        public SPFieldUserValue PersonField { get; set; }
        [SPFieldFlag]
        public SPFieldUrlValue HyperlinkField { get; set; }
        /// <summary>
        /// for multiple fields use 'TaxonomyFieldValueCollection'
        /// </summary>
        [SPFieldFlag]
        public TaxonomyFieldValue MetadataField { get; set; }
        [SPFieldFlag]
        public SPFieldLookupValue LookupSingleField { get; set; }
        [SPFieldFlag]
        public SPFieldLookupValueCollection LookupMultiField { get; set; }
        [SPFieldFlag]
        public string PublishingPageContent { get; set; }
        [SPFieldFlag]
        public DateTime? PublishingStartDate { get; set; }

        /// <summary>
        /// This property won't be mapped because of lack of the SPFieldFlag attribute. It is for only internal use.
        /// </summary>
        public string InternalProperty { get; set; }
    }
}