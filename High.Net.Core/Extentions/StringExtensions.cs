using EPiServer.Core;
using EPiServer.Framework.Localization;
using EPiServer.Globalization;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace High.Net.Core.Extentions
{
    public static class StringExtensions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StringExtensions));

        public static string TrimToNearestWord(this string input, int maxLength, string trailingText)
        {
            return TrimToNearestWord(input, maxLength, trailingText, false);
        }

        public static string TrimToNearestWord(this string input, int maxLength, string trailingText, bool removeHTML)
        {

            string result = input;

            if (removeHTML) input = StripHTML(result);

            if (!string.IsNullOrEmpty(input) && input.Length > maxLength)
            {
                int cutoffPoint = maxLength;
                for (int i = maxLength; i > 0; i--)
                {
                    if (char.IsWhiteSpace(input[i - 1]))
                    {
                        cutoffPoint = i - 1;
                        break;
                    }
                }
                result = input.Substring(0, cutoffPoint) + trailingText;
            }
            return result;
        }

        public static string StripHTML(string textToConvert)
        {
            if (!String.IsNullOrEmpty(textToConvert))
            {
                return Regex.Replace(textToConvert, @"<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
            }
            else
            {
                return "";
            }
        }

        public static string GetLocalizedCategory(this string categoryName)
        {
            //string currentLang = HttpContext.Current.Request.Headers["accept-language"];
            string currentLang = ContentLanguage.PreferredCulture.Name;

            if (string.IsNullOrEmpty(currentLang))
            {
                log.ErrorFormat("GetLocalizedCategory: currentLang IsNullOrEmpty");
            }

            string xPath = string.Format("/categories/category[@name='{0}']/description", categoryName);
            //PJUM-2502 - The filtering labels are missing
            string categoryDescription = LocalizationService.Current.GetString(xPath);//fyi, dropped the currentlang parameter as epi should uses current lang as default

            if (string.IsNullOrEmpty(categoryDescription))
            {
                //log.ErrorFormat("GetLocalizedCategory: xpath '{0}' not found", xPath);
                return string.Empty;
            }
            else
            {
                return categoryDescription;
            }
        }

        public static string IfNullOrEmpty(this string text, string defaultText)
        {
            if (string.IsNullOrEmpty(text))
                return defaultText;
            else
                return text;
        }

        public static string ToSafeString(this object text)
        {
            if (text == null)
                return string.Empty;
            else if (string.IsNullOrEmpty(text.ToString()))
                return string.Empty;
            else
                return text.ToString();
        }

        public static string Text(this XhtmlString xhtmlStr)
        {
            if (xhtmlStr != null)
            {
                return xhtmlStr.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool IsEmpty(this XhtmlString str)
        {
            return str == null ? true : str.IsEmpty;
        }
    }
}
