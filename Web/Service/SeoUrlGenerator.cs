//// --------------------------------------------------------------------------------------------------------------------
//// <copyright file="SeoUrlGenerator.cs" company="KOLF s.r.o.">
////   Lékárna KOLF s.r.o.
//// </copyright>
//// <summary>
////   The seo url generator.
//// </summary>
//// --------------------------------------------------------------------------------------------------------------------

//namespace Erzasoft.Service
//{
//    using System.Collections.Generic;
//    using System.Text.RegularExpressions;

//    /// <summary>
//    /// The seo url generator.
//    /// </summary>
//    public class SeoUrlGenerator : ISeoUrlGenerator
//    {
//        /// <summary>
//        /// The replace char.
//        /// </summary>
//        public static readonly IDictionary<char, char> ReplaceChar = new Dictionary<char, char>
//            {
//                { 'á', 'a' },
//                { 'č', 'c' },
//                { 'ď', 'd' },
//                { 'é', 'e' },
//                { 'ě', 'e' },
//                { 'í', 'i' },
//                { 'ň', 'n' },
//                { 'ó', 'o' },
//                { 'ř', 'r' },
//                { 'š', 's' },
//                { 'ť', 't' },
//                { 'ú', 'u' },
//                { 'ů', 'u' },
//                { 'ý', 'y' },
//                { 'ž', 'z' },
//            };

//        #region Implementation of ISeoUrlGenerator

//        /// <summary>
//        /// The convert.
//        /// </summary>
//        /// <param name="text">
//        /// The text.
//        /// </param>
//        /// <param name="maxLength">
//        /// The max length.
//        /// </param>
//        /// <returns>
//        /// The System.String.
//        /// </returns>
//        public string Convert(string text, int maxLength = 50)
//        {
//            var str = text.ToLower();

//            foreach (var replaceChar in ReplaceChar)
//            {
//                str = str.Replace(replaceChar.Key, replaceChar.Value);
//            }

//            // invalid chars, make into spaces
//            str = Regex.Replace(str, @"[^a-z0-9\s-]", string.Empty);

//            // convert multiple spaces/hyphens into one space       
//            str = Regex.Replace(str, @"[\s-]+", " ").Trim();

//            // cut and trim it
//            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();

//            // hyphens
//            str = Regex.Replace(str, @"\s", "-");

//            return str;
//        }

//        #endregion
//    }
//}
