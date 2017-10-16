using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using System.Data;

namespace SharePoint.Libraries.Entity
{
    public class EntityConverter<T> : EntityConverterBase where T : IEntity
    {
        public List<String> ViewFields { get; set; }
        public Boolean UseViewFields { get; set; }

        private PropertyInfo[] _Properties;
        private SPWeb _CurrentWeb;
        private Dictionary<string, string> _ItemEntityTitleMap;

        public EntityConverter(SPWeb web)
        {
            _Properties = typeof(T).GetProperties();
            _CurrentWeb = web;
            ViewFields = new List<string>();
            _ItemEntityTitleMap = InitializeFieldMap();
        }
        public T ConvertToEntity(DataRow dataRow)
        {
            var currentEntity = System.Activator.CreateInstance<T>();

            foreach (var mapPair in _ItemEntityTitleMap)
            {
                if (ViewFields.Contains(mapPair.Key))
                {
                    var property = currentEntity.GetType().GetProperty(mapPair.Value);

                    if (dataRow[mapPair.Key] != null && !string.IsNullOrEmpty(Convert.ToString(dataRow[mapPair.Key])))
                    {
                        IFieldAdapter adapter = FieldAdapterManager.GetAdapterFor(property.PropertyType);
                        object value = adapter.GetFieldValue(dataRow[mapPair.Key], property.PropertyType, _CurrentWeb);

                        if (value != null)
                        {
                            property.SetValue(currentEntity, value, null);
                        }
                    }
                }
            }

            return currentEntity;
        }
        public T ConvertToEntity(SPListItem listItem)
        {
            var currentEntity = System.Activator.CreateInstance<T>();

            SPField field = null;
            foreach (var mapPair in _ItemEntityTitleMap)
            {
                if (ViewFields.Count.Equals(0) || ViewFields.Contains(mapPair.Key))
                {
                    var property = currentEntity.GetType().GetProperty(mapPair.Value);
                    if (listItem.Fields.ContainsField(mapPair.Key) && listItem[mapPair.Key] != null)
                    {
                        field = listItem.Fields.GetField(mapPair.Key);
                        IFieldAdapter adapter = null;

                        if (field.Type.Equals(SPFieldType.Invalid))
                        {
                            adapter = InvalidFieldAdapterManager.GetAdapterFor(field.TypeAsString);
                        }
                        else
                        {
                            adapter = FieldAdapterManager.GetAdapterFor(field.Type);
                        }

                        object value = null;

                        if (adapter.GetType().Equals(typeof(AttachmentsFieldAdapter)))
                        {
                            value = adapter.GetFieldValue(listItem.Attachments, property.PropertyType, _CurrentWeb);
                        }
                        else
                        {
                            value = adapter.GetFieldValue(listItem[mapPair.Key], property.PropertyType, _CurrentWeb);
                        }

                        if (value != null)
                        {
                            property.SetValue(currentEntity, value, null);
                        }
                    }
                }
            }

            if (listItem.File != null && listItem.File.Exists && currentEntity is IDocumentEntity)
            {
                ((IDocumentEntity)currentEntity).FileUrl = listItem.File.Url;
                ((IDocumentEntity)currentEntity).FileName = listItem.File.Name;
                ((IDocumentEntity)currentEntity).FileIconUrl = listItem.File.IconUrl;
            }

            return currentEntity;
        }
        public SPListItem ConvertToListItem(SPListItem item, T entity)
        {
            foreach (var property in _Properties)
            {
                base.Dispose();


                var attributes = property.GetCustomAttributes(typeof(SPFieldFlag), true);

                if (attributes.Any())
                {
                    var attr = attributes[0] as SPFieldFlag;

                    string fieldName = string.Empty;

                    if (String.IsNullOrEmpty(attr.Name))
                    { fieldName = property.Name; }
                    else
                    { fieldName = attr.Name; }

                    if (!attr.RestrictUpdate)
                    {
                        if (property.Name.Equals(Constants.FieldNames.General.Attachments))
                        {
                            List<IAttachmentEntity> attachments = property.GetValue(entity, null) as List<IAttachmentEntity>;
                            if (attachments != null && attachments.Count > 0)
                            {
                                attachments.ForEach(a => item.Attachments.Add(a.FileName, a.FileBytes));
                            }
                        }
                        else
                        {

                            var fieldValue = property.GetValue(entity, null);

                            if (fieldValue != null)
                            {
                                if (property.PropertyType.FullName.Contains(Constants.TaxonomyPrefix))
                                {
                                    SetTaxonomyField(item, fieldName, property, entity);
                                }
                                else
                                {
                                    if (property.PropertyType.Equals(typeof(DateTime)))
                                    {
                                        DateTime fieldDateValue = Convert.ToDateTime(fieldValue);
                                        if (fieldDateValue.Equals(DateTime.MinValue))
                                        {
                                            item[fieldName] = null;
                                        }
                                        else
                                        {
                                            item[fieldName] = fieldValue;
                                        }
                                    }
                                    else
                                    {
                                        item[fieldName] = fieldValue;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return item;
        }
        private void SetTaxonomyField(SPListItem item, string fieldName, PropertyInfo property, T currentEntity)
        {
            var fieldValue = property.GetValue(currentEntity, null);
            var taxField = item.Fields.GetFieldByInternalName(fieldName) as TaxonomyField;

            if (taxField != null)
            {
                if (property.PropertyType.FullName.Equals(Constants.TaxonomyFieldValue))
                {
                    base.CurrentTaxonomyFieldValue = fieldValue as TaxonomyFieldValue;

                    if (base.CurrentTaxonomyFieldValue != null)
                    {
                        taxField.SetFieldValue(item, base.CurrentTaxonomyFieldValue);
                    }
                }
                else
                {
                    base.CurrentTaxonomyFieldValueCollection = fieldValue as TaxonomyFieldValueCollection;

                    if (base.CurrentTaxonomyFieldValueCollection != null)
                    {
                        taxField.SetFieldValue(item, base.CurrentTaxonomyFieldValueCollection);
                    }
                }
            }
        }
        private Boolean CheckViewFieldOperation(String attributeName)
        {
            if (UseViewFields)
            {
                return ViewFields.Contains(attributeName);
            }
            else
            {
                return true;
            }
        }
        private Dictionary<string, string> InitializeFieldMap()
        {
            var fieldMap = new Dictionary<string, string>();

            foreach (var property in _Properties)
            {
                var attributes = property.GetCustomAttributes(typeof(SPFieldFlag), true);

                if (attributes.Any())
                {
                    var attr = attributes[0] as SPFieldFlag;
                    string fieldName = string.Empty;

                    if (String.IsNullOrEmpty(attr.Name))
                    {
                        fieldName = property.Name;
                    }
                    else
                    {
                        fieldName = attr.Name;
                    }

                    if (CheckViewFieldOperation(fieldName))
                    {
                        fieldMap.Add(fieldName, property.Name);
                    }
                }
            }
            return fieldMap;
        }
    }
}