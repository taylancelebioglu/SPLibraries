using System.Collections.Generic;
using Microsoft.SharePoint;
using System;

namespace SharePoint.Libraries.Entity
{
    internal static class FieldAdapterManager
    {
        private static readonly Dictionary<SPFieldType, IFieldAdapter> fieldAdapters = new Dictionary<SPFieldType, IFieldAdapter>() 
                                                                                      {
                                                                                        { SPFieldType.Text, new DefaultFieldAdapter() },
                                                                                        { SPFieldType.Number, new NumberFieldAdapter() },
                                                                                        { SPFieldType.Invalid, new InvalidFieldAdapter() }, 
                                                                                        { SPFieldType.Lookup, new LookupFieldAdapter() },
                                                                                        { SPFieldType.URL, new UrlFieldAdapter() } ,
                                                                                        { SPFieldType.DateTime, new DateTimeAdapter() },
                                                                                        { SPFieldType.User, new UserFieldAdapter() },
                                                                                        { SPFieldType.File, new FileFieldAdapter() },
                                                                                        { SPFieldType.Choice, new ChoiceFieldAdapter() },
                                                                                        { SPFieldType.MultiChoice, new MultiChoiceFieldAdapter() },
                                                                                        { SPFieldType.Attachments, new AttachmentsFieldAdapter() }
                                                                                      };

        private static readonly Dictionary<String, IFieldAdapter> fieldAdaptersForDataRow = new Dictionary<String, IFieldAdapter>() 
                                                                                      {
                                                                                        { "String", new DefaultFieldAdapter() },
                                                                                        { "Int32", new NumberFieldAdapter() },
                                                                                        { "Double", new NumberFieldAdapter() },
                                                                                        { "Single", new NumberFieldAdapter() },
                                                                                        { "Int64", new NumberFieldAdapter() },
                                                                                        { "Decimal", new NumberFieldAdapter() },
                                                                                        { "DateTime", new DateTimeAdapter() },
                                                                                        { "TaxonomyFieldValue", new InvalidFieldAdapter() }, 
                                                                                        { "TaxonomyFieldValueCollection", new InvalidFieldAdapter() },
                                                                                        { "SPFieldLookupValue", new LookupFieldAdapter() },
                                                                                        { "SPFieldLookupValueCollection", new LookupFieldAdapter() },
                                                                                        { "SPFieldUrlValue", new UrlFieldAdapter() } ,
                                                                                        { "SPFieldUserValue", new UserFieldAdapter() },
                                                                                        { "SPFieldUserValueCollection", new UserFieldAdapter() },
                                                                                        { "e", new FileFieldAdapter() },
                                                                                        { "Boolean", new BooleanFieldAdapter() },
                                                                                        { "SPFieldChoiceValue", new ChoiceFieldAdapter() },
                                                                                        { "SPFieldMultiChoiceValue", new MultiChoiceFieldAdapter() }
                                                                                      };

        internal static IFieldAdapter GetAdapterFor(SPFieldType type)
        {
            if (fieldAdapters.ContainsKey(type))
            {
                return fieldAdapters[type];
            }
            else
            {
                return fieldAdapters[SPFieldType.Text];
            }
        }
        internal static IFieldAdapter GetAdapterFor(Type propertyType)
        {
            if (fieldAdaptersForDataRow.ContainsKey(propertyType.Name))
            {
                return fieldAdaptersForDataRow[propertyType.Name];
            }
            else if (propertyType.Name.Equals("Nullable`1") && propertyType.FullName.Contains("DateTime"))
            {
                return fieldAdaptersForDataRow["DateTime"];
            }
            else
            {
                return fieldAdaptersForDataRow["String"];
            }
        }
    }
}