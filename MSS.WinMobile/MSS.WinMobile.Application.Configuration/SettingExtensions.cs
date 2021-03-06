﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace MSS.WinMobile.Application.Configuration
{
    public static class SettingExtensions
    {
        public static T As<T>(this ISetting setting) {
            return To<T>(setting.Value);
        }

        public static T[] AsArray<T>(this ISetting setting) {
            var xmlDocument = new XmlDocument();
            var xmlElement = xmlDocument.CreateElement("root");
            xmlElement.InnerXml = setting.Value;
            xmlDocument.AppendChild(xmlElement);

            var items = new List<T>();
            for (int i = 0; i < xmlElement.ChildNodes.Count; i++)
            {
                items.Add(To<T>(xmlElement.ChildNodes[i].InnerXml));
            }

            return items.ToArray();
        }

        public static Dictionary<TK, TV> AsDictionary<TK, TV>(this ISetting setting)
        {
            var xmlDocument = new XmlDocument();
            var xmlElement = xmlDocument.CreateElement("root");
            xmlElement.InnerXml = setting.Value;
            xmlDocument.AppendChild(xmlElement);

            var items = new Dictionary<TK, TV>();
            for (int i = 0; i < xmlElement.ChildNodes.Count; i++) {
                var keyElement = xmlElement.ChildNodes[i].SelectSingleNode(@"Key");
                var valueElement = xmlElement.ChildNodes[i].SelectSingleNode(@"Value");
                if (keyElement != null && valueElement != null) {
                    items.Add(To<TK>(keyElement.InnerXml), To<TV>(valueElement.InnerXml));
                }
            }

            return items;
        }

        private static T To<T>(string value) {
            object result;

            if (string.IsNullOrEmpty(value))
                return default(T);
            
            if (typeof (T) == typeof(int)) {
                result = Int32.Parse(value);
            }
            else if (typeof (T) == typeof (DateTime)) {
                result = DateTime.Parse(value, DateTimeFormatInfo.InvariantInfo);
            }
            else if (typeof (T) == typeof (string)) {
                result = value;
            }
            else if (typeof (T) == typeof (bool)) {
                result = Boolean.Parse(value);
            }
            else {
                throw new UnsupportedTypeException(typeof (T));
            }

            return (T)result;
        }
    }

    public class UnsupportedTypeException : Exception {
        public UnsupportedTypeException(Type type) :
            base(string.Format("Type \"{0}\" not supported", type)) {
        }
    }
}
