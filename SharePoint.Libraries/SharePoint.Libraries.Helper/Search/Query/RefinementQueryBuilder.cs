using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePoint.Libraries.Helper.Search
{
    /// <summary>
    /// Basic query builder which can be used for querystring search queries
    /// </summary>
    public class RefinementQueryBuilder
    {


        /// <summary>
        /// Generates refinement token according to value.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static string GetRefinementToken(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return string.Empty;
            }
            string base64Val = Convert.ToBase64String(Encoding.UTF8.GetBytes(keyword));
            byte[] bytes = Convert.FromBase64String(base64Val);
            string hex = BitConverter.ToString(bytes);
            var token = string.Format("ǂǂ{0}", hex.Replace("-", string.Empty).ToLower());
            return token;
        }
    }
}