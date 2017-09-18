using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SharePoint.Libraries.Helper.Search
{
    /// <summary>
    /// For using with url queries
    /// </summary>
    public class RefinementUrlQueryModel
    {
        /// <summary>
        /// Name value will be serialized as 'n'
        /// </summary>
        [XmlAttribute(AttributeName = "n")]
        public string RefinerName { get; set; }
        /// <summary>
        /// This value is for coding and not will be serialized for the query. Instead of this token will be used
        /// </summary>
        [XmlIgnore]
        public List<string> RefinerValues { get; set; }
        /// <summary>
        /// Generates actual token for the query.
        /// </summary>
        [XmlAttribute(AttributeName = "t")]
        public List<string> RefinerTokens
        {
            get
            {
                List<string> tokens = new List<string>();

                if (RefinerValues.Any())
                {
                    foreach (string value in RefinerValues)
                    {
                        tokens.Add(string.Format("\"{0}\"", RefinementQueryBuilder.GetRefinementToken(value)));
                    }
                }
                return tokens;
            }
        }
        /// <summary>
        /// or,and
        /// </summary>
        [XmlAttribute(AttributeName = "o")]
        public string Operator { get; set; }
        /// <summary>
        /// With basic queries leave it false
        /// </summary>
        [XmlAttribute(AttributeName = "k")]
        public bool UseKeywordQuery { get; set; }
        /// <summary>
        /// YOu can find more information on this site https://www.eliostruyf.com/part-5-search-refiner-control-methods-explained/
        /// </summary>
        [XmlAttribute(AttributeName = "m")]
        public string ValueMapping { get; set; }
    }
}