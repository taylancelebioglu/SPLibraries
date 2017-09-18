using System.Collections.Generic;
using System.Xml.Serialization;

namespace SharePoint.Libraries.Helper.Search.Query
{
    /// <summary>
    /// Refiner query main object
    /// </summary>
    public class UrlQueryModel
    {
        /// <summary>
        /// query or text
        /// </summary>
        [XmlAttribute(AttributeName = "k")]
        public string Keyword { get; set; }
        /// <summary>
        /// More than one refiners can be used in the same query
        /// </summary>
        [XmlAttribute(AttributeName = "r")]
        public List<RefinementUrlQueryModel> Refiners { get; set; }
    }
}