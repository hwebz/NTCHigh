using EPiServer.Core;
using System.Collections.Generic;
using System.Linq;

namespace High.Net.Core
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static bool IsNullOrEmpty(this ContentArea contentArea)
        {
            return contentArea == null || contentArea.FilteredItems.IsNullOrEmpty();
        }

        public static string ToSimpleString<T>(this T xhtmlStr) where T : XhtmlString
        {
            return xhtmlStr == null ? string.Empty : xhtmlStr.ToString();
        }
    }
}