using System;
using System.Collections.Generic;
using System.Text;
using Mss.WinMobile.Domain.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MSS.WinMobile.Infrastructure.Server
{
    public class ManagerRepository : GenericRepository<Manager>
    {
        const string CONTROLLER_NAME = "managers";

        MssServer _server;

        public ManagerRepository(MssServer server) {
            _server = server;
        }

        public override Manager GetById(int id)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(
                string.Format(@"http://{0}:{1}/{2}/{3}.json",
                _server.Address,
                _server.Port,
                CONTROLLER_NAME,
                id));

            webRequest.Method = "GET";
            webRequest.ContentType = "application/json; charset=utf-8";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream())) 
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Manager>(json);
            }
        }

        public override IEnumerable<Manager> Find()
        {
            throw new NotImplementedException();
        }

        public override void Add(Manager entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Manager entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Manager entity)
        {
            throw new NotImplementedException();
        }
    }
}
