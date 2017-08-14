using System;
using Microsoft.SharePoint;

namespace SharePoint.Libraries.Entity
{
    internal interface IFieldAdapter
    {
        object GetFieldValue(object value, Type objectType, SPWeb web);
    }
}