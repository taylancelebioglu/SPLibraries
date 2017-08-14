using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;

namespace SharePoint.Libraries.Entity
{
    public class EntityConverterBase : IDisposable
    {
        public TaxonomyField CurrentTaxonomyField { get; set; }
        public TaxonomyFieldValue CurrentTaxonomyFieldValue { get; set; }
        public TaxonomyFieldValueCollection CurrentTaxonomyFieldValueCollection { get; set; }
        public SPFieldUrlValue CurrentSPFieldUrlValue { get; set; }
        public SPFieldUserValueCollection CurrentSPFieldUserValueCollection { get; set; }
        public SPFieldLookupValue CurrentSPFieldLookupValue { get; set; }
        public SPFieldLookupValueCollection CurrentSPFieldLookupValueCollection { get; set; }
        public SPFieldMultiChoiceValue CurrentSPFieldMultiChoiceValue { get; set; }

        public void Dispose()
        {
            this.CurrentTaxonomyField = null;
            this.CurrentTaxonomyFieldValue = null;
            this.CurrentTaxonomyFieldValueCollection = null;
            this.CurrentSPFieldUrlValue = null;
            this.CurrentSPFieldUserValueCollection = null;
            this.CurrentSPFieldLookupValue = null;
            this.CurrentSPFieldLookupValueCollection = null;
            this.CurrentSPFieldMultiChoiceValue = null;
        }
    }
}