using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AspNetIdentity.WebClientAdmin.Providers
{
    public class DictionaryModel
    {
        public string Encode(DateTime date)
        {
            var formattedDate = date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return System.Net.WebUtility.UrlEncode(formattedDate);
        }


        public Dictionary<string, string> ToDictionary(object MyObject)
        {
            Dictionary<string, string> MyDictionary = new Dictionary<string, string>();

            string Valor = "";
            string nombre = "";
            int i = 0;
            try
            {
                foreach (PropertyDescriptor Descriptor in TypeDescriptor.GetProperties(MyObject))
                {
                    i++;

                    string debugger = Descriptor.PropertyType.FullName.ToString() + " " + Descriptor.Name;
                    System.Diagnostics.Debug.WriteLine(debugger);

                    nombre = Descriptor.Name;

                    if (Descriptor.PropertyType.FullName.Equals("System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]") || Descriptor.PropertyType.FullName.Equals("System.DateTime"))
                    {
                        var valorDate = Descriptor.GetValue(MyObject).ToString();
                        DateTime parsedDate = DateTime.Parse(valorDate);
                        Valor = Encode(parsedDate);
                    }
                    else {
                        var value = Descriptor.GetValue(MyObject);
                        if (value != null)
                        {
                            Valor = Descriptor.GetValue(MyObject).ToString();
                        }
                       
                    }
                    MyDictionary.Add(nombre, Valor.ToString());
                }
            }
            catch (InvalidCastException e)
            {
                throw new Exception(e.Message);
            }
            return MyDictionary;
        }

        public Dictionary<string, object> ToDictionary2(object MyObject)
        {
            Dictionary<string, object> MyDictionary = new Dictionary<string, object>();

            string Valor = "";
            string nombre = "";
            int i = 0;
            try
            {
                foreach (PropertyDescriptor Descriptor in TypeDescriptor.GetProperties(MyObject))
                {
                    i++;

                    string debugger = Descriptor.PropertyType.FullName.ToString() + " " + Descriptor.Name;
                    System.Diagnostics.Debug.WriteLine(debugger);

                    nombre = Descriptor.Name;

                    if (Descriptor.PropertyType.FullName.Equals("System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]") || Descriptor.PropertyType.FullName.Equals("System.DateTime"))
                    {
                        var valorDate = Descriptor.GetValue(MyObject).ToString();
                        DateTime parsedDate = DateTime.Parse(valorDate);
                        Valor = Encode(parsedDate);
                    }
                    else
                    {
                        var value = Descriptor.GetValue(MyObject);
                        if (value != null)
                        {
                            Valor = Descriptor.GetValue(MyObject).ToString();
                        }
                        else
                        {
                            Valor = string.Empty;
                        }
                    }
                    MyDictionary.Add(nombre, Valor.ToString());
                }
            }
            catch (InvalidCastException e)
            {
                throw new Exception(e.Message);
            }
            return MyDictionary;
        }

    }
}