using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebClient.Providers
{
    public static class Extensions
    {
        public static Dictionary<string, string> ToDictionary(this object MyObject)
        {
            Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
            foreach (PropertyDescriptor Descriptor in TypeDescriptor.GetProperties(MyObject))
            {
                string valor = Descriptor.GetValue(MyObject).ToString();
                MyDictionary.Add(Descriptor.Name, valor);
            }

            return MyDictionary;
        }
    }
}


