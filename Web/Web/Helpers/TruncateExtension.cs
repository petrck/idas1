using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Erzasoft.Web.Helpers
{
    public static class TruncateExtension
    {
        public static string truncate(this string value, int maxLength)
        {
            var clearHtml = Regex.Replace(value, @"<[^>]*>", string.Empty);
            var decoded = HttpUtility.HtmlDecode(clearHtml);

            return decoded.Length <= maxLength ? decoded : decoded.Substring(0, maxLength) + "...";
        }
    }
}