using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace SharePoint.Libraries.Entity
{
    public class ViewFieldsBuilder : IViewFieldsBuilder
    {
        private StringBuilder _Builder { get; set; }
        private Type _EntityType { get; set; }
        public List<string> Fields { get; set; }
        private readonly static Dictionary<string, string> ComplexMultiTypes = new Dictionary<string, string>()
            {
                { "TaxonomyFieldValueCollection", "TaxonomyFieldTypeMulti" },
                { "SPFieldLookupValueCollection", "LookupMulti" },
                { "SPFieldUserValueCollection", "UserMulti" },
            };

        private readonly static string[] RestrictedViewFields = new string[] { "ListId", "WebId" };
        public ViewFieldsBuilder(Type entityType)
        {
            _Builder = new StringBuilder();
            Fields = new List<string>();
            this._EntityType = entityType;
        }
        public String GetViewFields()
        {
            return GetViewFields(false);
        }
        public String GetViewFields(bool useSPSiteDataQuery)
        {
            PropertyInfo[] pInfos = _EntityType.GetProperties();

            foreach (PropertyInfo property in pInfos)
            {
                var attributes = property.GetCustomAttributes(typeof(SPFieldFlag), true);

                if (attributes.Any())
                {
                    string fieldName = string.Empty;
                    var attr = attributes[0] as SPFieldFlag;

                    if (String.IsNullOrEmpty(attr.Name))
                    {
                        fieldName = property.Name;
                    }
                    else
                    {
                        fieldName = attr.Name;
                    }
                    Fields.Add(fieldName);

                    if (!(useSPSiteDataQuery && RestrictedViewFields.Contains(property.Name)))
                    {
                        if (ComplexMultiTypes.ContainsKey(property.PropertyType.Name))
                        {
                            _Builder.Append(String.Format(Constants.ViewFieldsMultiTypesFormat, fieldName, ComplexMultiTypes[property.PropertyType.Name]));
                        }
                        else
                        {
                            _Builder.Append(String.Format(Constants.ViewFieldsFormat, fieldName));
                        }
                    }
                }
            }
            return _Builder.ToString();
        }
        public List<String> GetFields(String queryViewXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(queryViewXml);

            _FindViewFieldsNode(doc.ChildNodes);

            foreach (XmlNode fieldRefNode in _FoundNode.ChildNodes)
            {
                string fieldName = fieldRefNode.Attributes[Constants.ViewFieldsXmlAttributeName].Value;
                Fields.Add(fieldName);
            }
            return Fields;
        }
        private XmlNode _FoundNode;
        private void _FindViewFieldsNode(XmlNodeList nodes)
        {
            if (_FoundNode == null)
            {
                foreach (XmlNode node in nodes)
                {
                    if (node.Name.Equals(Constants.ViewFieldsXmlNodeName))
                    {
                        _FoundNode = node;
                        break;
                    }
                    else
                    {
                        _FindViewFieldsNode(node.ChildNodes);
                    }
                }
            }
        }
        public List<string> ExtractViewFields(string fieldNodes)
        {
            List<string> fields = new List<string>();

            fieldNodes = fieldNodes.Replace("<FieldRef", string.Empty);
            fieldNodes = fieldNodes.Replace("Name=", string.Empty);
            string[] seperated = fieldNodes.Split("/>".ToCharArray());

            foreach (string field in seperated)
            {
                string fi = field.Trim();
                fi = fi.Replace("\"", string.Empty).Replace("'", string.Empty);
                if (!string.IsNullOrEmpty(fi))
                {
                    fields.Add(fi);
                }
            }
            return fields;
        }
    }
}