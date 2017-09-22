using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Core.Extentions
{

    public static class TypeExtensions
    {
        #region PageTypeName

        public static string GetPageTypeName(this Type pt)
        {
            //TODO upgrade fix this
            /*
            object[] attrColl = pt.GetCustomAttributes(typeof (PageTypeAttribute), false);
            if (attrColl.Length > 0)
            {
                var attr = attrColl[0] as PageTypeAttribute; // Get first attribute
                if (attr != null && !string.IsNullOrEmpty(attr.Name))
                {
                    return attr.Name;
                }
            } 
             */
            return pt.Name;
        }

        public static string[] GetPageTypeNameList(Type[] pageTypes)
        {
            var pageTypeList = new string[pageTypes.Length];
            int i = 0;
            foreach (var pt in pageTypes)
            {
                string name = GetPageTypeName(pt);
                if (!string.IsNullOrEmpty(name))
                {
                    pageTypeList[i] = name;
                    i++;
                }
            }
            return pageTypeList;
        }

        #endregion

        public static T GetAttributeFromType<T>(Type objType)
        {
            if (objType != null)
            {
                var attrArr = objType.GetCustomAttributes(typeof(T), false);
                if (attrArr.Length > 0)
                {
                    var attr = attrArr[0];
                    if (attr is T)
                    {
                        return (T)attr;
                    }
                }
            }
            return default(T);
        }

        public static List<PropertyInfo> GetAttributePropertiesFromType<T>(Type objType)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();

            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                foreach (object attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is T)
                    {
                        result.Add(property);
                    }
                }
            }
            return result.Count > 0 ? result : null;
        }

        public static Dictionary<PropertyInfo, T> GetAttributesFromType<T>(Type objType)
        {
            var result = new Dictionary<PropertyInfo, T>();

            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                foreach (object attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is T)
                    {
                        result.Add(property, (T)attribute);
                    }
                }
            }
            return result.Count > 0 ? result : null;
        }
    }
}
