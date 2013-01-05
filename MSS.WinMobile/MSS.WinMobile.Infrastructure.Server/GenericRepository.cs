using System;
using System.Collections.Generic;
using System.Text;
using Mss.WinMobile.Domain.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MSS.WinMobile.Infrastructure.Server
{
    public class GenericRepository<T> where T : Entity
    {
        MssServer _mssServer;

        public GenericRepository(MssServer mssServer) {
            _mssServer = mssServer;
        }

        public T GetById(int id) 
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(
                string.Format(@"http://{0}:{1}/{2}/{3}.json",
                _mssServer.Address,
                _mssServer.Port,
                MssServerHelper.GetControllerName(typeof(T)),
                id));

            webRequest.Method = "GET";
            webRequest.ContentType = "application/json; charset=utf-8";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public IEnumerable<T> Find()
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(
                string.Format(@"http://{0}:{1}/{2}.json",
                _mssServer.Address,
                _mssServer.Port,
                MssServerHelper.GetControllerName(typeof(T))));

            webRequest.Method = "GET";
            webRequest.ContentType = "application/json; charset=utf-8";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T[]>(json);
            }
        }

        public void Add(T entity)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(
                string.Format(@"http://{0}:{1}/{2}.json",
                _mssServer.Address,
                _mssServer.Port,
                MssServerHelper.GetControllerName(typeof(T))));

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new LowercaseContractResolver();
                string json = JsonConvert.SerializeObject(entity, Formatting.Indented, settings);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            webRequest.GetResponse();
        }

        public void Update(T entity)
        { }

        public void Delete(T entity)
        { }
    }

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
