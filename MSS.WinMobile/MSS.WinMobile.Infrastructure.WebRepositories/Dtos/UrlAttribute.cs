using System;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UrlAttribute : Attribute
    {
        public UrlAttribute(string url) { _url = url; }
        readonly string _url;
        public string Url {
            get { return _url; }
        }
    }
}
