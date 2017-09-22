using System.Collections.Generic;
using System.Linq;

namespace High.Net.Core.Extentions
{
    public static class ExtensionMethods
    {
        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || !list.Any<T>();
        }
    }
}