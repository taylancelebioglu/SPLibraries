namespace SharePoint.Libraries.Entity
{
    public sealed class Constants
    {
        public static string SiteUrl = "SiteUrl";
        public static string TempFileVirtualDirectory = "tempfiles";
        public const string ConfigurationPathKey = "ConfigurationPathKey";
        public static string ViewFieldsFormat = "<FieldRef Name='{0}' />";
        public static string ViewFieldsMultiTypesFormat = "<FieldRef Name='{0}' Nullable='true' Type='{1}'/>";
        public static string ViewFieldsXmlNodeName = "ViewFields";
        public static string ViewFieldsXmlAttributeName = "Name";
        public static string TaxonomyPrefix = "Microsoft.SharePoint.Taxonomy";
        public static string TaxonomyField = "Microsoft.SharePoint.Taxonomy.TaxonomyField";
        public static string TaxonomyFieldValue = "Microsoft.SharePoint.Taxonomy.TaxonomyFieldValue";
        public static string TaxonomyFieldValueCollection = "Microsoft.SharePoint.Taxonomy.TaxonomyFieldValueCollection";
        public static string MultiLookupFieldType = "LookupMulti";
        public static string MultiUserField = "UserMulti";

        public sealed class FieldNames
        {
            public sealed class General
            {
                public const string ID = "ID";
                public const string TITLE = "Title";
                public const string CREATED = "Created";
                public const string MODIFIED = "Modified";
                public const string CREATEDBY = "Author";
                public const string MODIFIEDBY = "Editor";
                public const string ENCODEDABSURL = "EncodedAbsUrl";
                public const string BODY = "Body";
                public const string DESCRIPTION = "Description";
                public const string DocumentIDValue = "_dlc_DocId";
                public const string Author = "_Author";
                public const string Copyright = "wic_System_Copyright";
                public const string Attachments = "Attachments";
            }
        }
    }
}