using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace Focus.Infrastructure.Web.Extensions
{
    public static class EnumExtensions
    {
        public static List<dynamic> GetAllItems(this Type enumName)
        {
            List<dynamic> list = new List<dynamic>();
            // get enum fileds
            FieldInfo[] fields = enumName.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsEnum)
                {
                    continue;
                }
                // get enum value
                int value = (int)enumName.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                string text = field.Name;
                string description = string.Empty;
                object[] array = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (array.Length > 0)
                {
                    description = ((DescriptionAttribute)array[0]).Description;
                }
                else
                {
                    description = ""; //none description,set empty
                }
                //add to list
                dynamic obj = new ExpandoObject();
                obj.Value = value;
                obj.Text = text;
                obj.Description = description;
                list.Add(obj);
            }
            return list;
        }

        public static string GetDescriptionByName<T>(this T enumItemName)
        {
            FieldInfo fi = enumItemName.GetType().GetField(enumItemName.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return enumItemName.ToString();
            }
        }

        public static string GetDisplayName(this Enum obj)
        {
            Type type = obj.GetType();
            MemberInfo[] memInfo = type.GetMember(obj.ToString()); if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false); if (attrs != null && attrs.Length > 0) return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attrs[0]).Name;
            }
            return obj.ToString();
        }
    }
}
