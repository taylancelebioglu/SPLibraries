using System;

namespace SharePoint.Libraries.Entity
{
    public static class ViewFieldsFactory
    {
        public static IViewFieldsBuilder GetBuilder(Type entityType)
        {
            return new ViewFieldsBuilder(entityType);
        }
    }
}