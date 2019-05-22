using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Finance.Commom.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? 
                attributes[0].Description : value.ToString();
        }

        public static Dictionary<Enum, string> GetDescriptions(this Enum enumerador)
        {
            if (enumerador == null)
                return null;

            Dictionary<Enum, string> dictionary = new Dictionary<Enum, string>();

            foreach (Enum itemEnumerado in Enum.GetValues(enumerador.GetType()))
            {
                dictionary.Add(itemEnumerado, itemEnumerado.GetDescription());
            }

            return dictionary;
        }
    }
}
