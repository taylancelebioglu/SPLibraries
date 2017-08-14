using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing.Fields;
using Microsoft.SharePoint.Taxonomy;
using System;

namespace SharePoint.Libraries.Entity
{
    public class InvalidDefaultAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            return value;
        }
    }

    public class PublishingPageImageAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            if (objectType == typeof(ImageFieldValue))
            {
                return value as ImageFieldValue;
            }
            else
            {
                return ((ImageFieldValue)value).ImageUrl;
            }
        }
    }

    public class PublishingPageContentAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            return Convert.ToString(value);
        }
    }

    public class TaxonomyAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            if (value.GetType() == objectType)
            {
                return value as TaxonomyFieldValue;
            }
            return new TaxonomyFieldValue(value.ToString());
        }
    }

    public class TaxonomyMultiAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            if (value.GetType() == objectType)
            {
                return value as TaxonomyFieldValueCollection;
            }
            return new TaxonomyFieldValueCollection(value.ToString());
        }
    }

    public class PublishingScheduleAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            return value as DateTime?;
        }
    }
}