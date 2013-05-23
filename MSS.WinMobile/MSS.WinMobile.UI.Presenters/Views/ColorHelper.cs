using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace MSS.WinMobile.UI.Presenters.Views {
    public static class ColorHelper {

        static readonly Dictionary<Color, string> MColorNames = new Dictionary<Color, string>();
        static readonly Dictionary<string, Color> MColorValues = new Dictionary<string, Color>();

        static ColorHelper() {
            FieldInfo[] fi = typeof(Color).GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (var t in fi) {
                AddColor(t.Name, (Color)t.GetValue(null));
            }
            PropertyInfo[] pi = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (PropertyInfo t in pi) {
                if (t.PropertyType == typeof(Color)) {
                    AddColor(t.Name, (Color)t.GetValue(null, null));
                }
            }
            pi = typeof(SystemColors).GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (PropertyInfo t in pi) {
                if (t.PropertyType == typeof(Color)) {
                    AddColor(t.Name, (Color)t.GetValue(null, null));
                }
            }
        }

        private static void AddColor(string name, Color color) {
            if (!MColorNames.ContainsKey(color)) {
                MColorNames.Add(color, name);
                MColorValues.Add(name, color);
            }
        }


        public static string ColorToString(Color color) {
            string name;
            if (!MColorNames.TryGetValue(color, out name)) {
                name = color.ToString();
            }
            return name;
        }


        public static Color StringToColor(string colorName) {
            Color color;
            if (!MColorValues.TryGetValue(colorName, out color)) {
                if (!MColorValues.TryGetValue(string.Format("Color [{0}]", colorName), out color)) {
                    try {
                        color = (Color)Enum.Parse(typeof(Color), colorName, true);
                    }
                    catch (Exception) {
                        color = Color.Empty;
                    }
                }
            }
            return color;
        }
    }
}
