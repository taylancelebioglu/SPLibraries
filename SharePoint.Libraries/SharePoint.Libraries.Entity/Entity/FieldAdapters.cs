using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharePoint.Libraries.Entity
{
    public class DefaultFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            if (objectType.Equals(typeof(Guid)))
            {
                return new Guid(value as string);
            }
            return value;
        }
    }

    public class FileFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            return null;
        }
    }

    public class InvalidFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            IFieldAdapter invalidAdapter = InvalidFieldAdapterManager.GetAdapterFor(objectType.Name);
            return invalidAdapter.GetFieldValue(value, objectType, web);
        }
    }

    public class LookupFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            object returnValue = null;

            if (objectType.Equals(typeof(SPFieldLookupValueCollection)))
            {
                returnValue = new SPFieldLookupValueCollection(value as string);
            }
            else
            {
                returnValue = new SPFieldLookupValue(value as string);
            }
            return returnValue;
        }
    }

    public class ChoiceFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            return value as string;
        }
    }

    public class AttachmentsFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            List<IAttachmentEntity> values = new List<IAttachmentEntity>();

            SPAttachmentCollection attachments =  value as SPAttachmentCollection;

            if (attachments != null && attachments.Count > 0)
            {
                attachments.OfType<string>().ToList().ForEach((a) => 
                {
                    IAttachmentEntity attachment = new AttachmentEntity();
                    attachment.FileUrl = string.Format("{0}{1}", attachments.UrlPrefix, a);
                    values.Add(attachment);
                });
            }
            return values;
        }
    }

    public class MultiChoiceFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            return new SPFieldMultiChoiceValue(value as string);
        }
    }

    public class NumberFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            if (objectType.Equals(typeof(int)))
            {
                string stringValue = value.ToString();
                if (stringValue.Contains("."))
                {
                    stringValue = stringValue.Split('.')[0];
                }
                else if (stringValue.Contains(","))
                {
                    stringValue = stringValue.Split(',')[0];
                }


                return Int32.Parse(Convert.ToString(stringValue));
            }
            else
            {
                return Convert.ChangeType(value, objectType, web.UICulture);
            }
        }
    }

    public class UrlFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            return new SPFieldUrlValue(value as string);
        }
    }

    public class UserFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            string userValue = Convert.ToString(value);
            if (objectType.Equals(typeof(SPFieldUserValueCollection)))
            {
                return new SPFieldUserValueCollection(web, userValue);
            }
            else
            {
                return new SPFieldUserValue(web, userValue);
            }
        }
    }

    public class DateTimeAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                return Convert.ToDateTime(value);
            }
            return null;
        }
    }

    public class BooleanFieldAdapter : IFieldAdapter
    {
        public object GetFieldValue(object value, Type objectType, SPWeb web)
        {
            if (string.Equals(value, "1"))
                return true;
            else if (string.Equals(value, "0"))
                return false;
            return Convert.ChangeType(value, objectType);
        }
    }
}