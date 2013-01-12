using System;
using System.Collections.Generic;
using System.Xml;
using CodeBetter.Json;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using MSS.WinMobile.Infrastructure.Remote.Data.Repositories.Specifications;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        private readonly RequestDispatcher _requestDispatcher;

        public GenericRepository(RequestDispatcher requestDispatcher)
        {
            _requestDispatcher = requestDispatcher;
        }

        public T GetById(int id)
        {
            string json = _requestDispatcher.Dispatch(string.Format(@"{0}/{1}.json",
                                                                    ResourceUriHelper.GetControllerName(typeof (T)),
                                                                    id), "GET");

            return Converter.Deserialize<T>(json);
        }

        public T[] Find()
        {
            string json = _requestDispatcher.Dispatch(
                string.Format(@"{0}.json", ResourceUriHelper.GetControllerName(typeof (T))), "GET");

            return Converter.Deserialize<T[]>(json);
        }

        public T[] Find(Specification<T> specification) {
            string queryString = SpecificationConverter<T>.ToQueryString(specification);

            string json = _requestDispatcher.Dispatch(
                string.Format(@"{0}.json?{1}", ResourceUriHelper.GetControllerName(typeof(T)), queryString), "GET");

            return Converter.Deserialize<T[]>(json);
        }

        public void Add(T entity)
        {
            string uri = string.Format(@"{0}.json",
                ResourceUriHelper.GetControllerName(typeof(T)));

            //var settings = Converter.Deserialize new JsonSerializerSettings {ContractResolver = new LowercaseContractResolver()};
            
            string json = Converter.Serialize(entity);

            _requestDispatcher.Dispatch(uri, "POST", json);
        }

        public void Update(T entity)
        {
            string uri = string.Format(@"{0}/{1}.json",
                ResourceUriHelper.GetControllerName(typeof(T)),
                entity.Id);

            //var settings = new JsonSerializerSettings {ContractResolver = new LowercaseContractResolver()};
            //string json = JsonConvert.SerializeObject(entity, Formatting.Indented, settings);
            string json = Converter.Serialize(entity);

            _requestDispatcher.Dispatch(uri, "PUT", json);
        }

        public void Delete(T entity)
        {
            string uri = string.Format(@"{0}/{1}.json",
                ResourceUriHelper.GetControllerName(typeof(T)),
                entity.Id);

            _requestDispatcher.Dispatch(uri, "DELETE", string.Empty);
        }
    }

    //public class LowercaseContractResolver : DefaultContractResolver
    //{
    //    protected override string ResolvePropertyName(string propertyName)
    //    {
    //        // Get upper case characters positions
    //        var positions = new List<int>();

    //        for (var i = 1; i < propertyName.Length; i++) {
    //            if (Char.IsUpper(propertyName[i])) {
    //                positions.Add(i);
    //            }
    //        }

    //        // insert _ character in all positions
    //        for (var i = positions.Count - 1; i >= 0; i--) {
    //            propertyName = propertyName.Insert(positions[i], "_");
    //        }

    //        return propertyName.ToLower();
    //    }
    //}
}
