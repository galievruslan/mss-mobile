using System.Text;
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

            return Json.JsonDeserializer.Deserialize<T>(json);
        }

        public T[] Find()
        {
            string json = _requestDispatcher.Dispatch(
                string.Format(@"{0}.json", ResourceUriHelper.GetControllerName(typeof (T))), "GET");

            return Json.JsonDeserializer.Deserialize<T[]>(json);
        }

        public T[] Find(Specification<T> specification) {
            string queryString = SpecificationConverter<T>.ToQueryString(specification);

            string json = _requestDispatcher.Dispatch(
                string.Format(@"{0}.json?{1}", ResourceUriHelper.GetControllerName(typeof(T)), queryString), "GET");

            return Json.JsonDeserializer.Deserialize<T[]>(json);
        }

        public void Add(T entity)
        {
            string uri = string.Format(@"{0}.json",
                ResourceUriHelper.GetControllerName(typeof(T)));
            
            var jsonBuilder = new StringBuilder();
            Json.JsonSerializer.Serialize(jsonBuilder, entity);

            _requestDispatcher.Dispatch(uri, "POST", jsonBuilder.ToString());
        }

        public void Update(T entity)
        {
            string uri = string.Format(@"{0}/{1}.json",
                ResourceUriHelper.GetControllerName(typeof(T)),
                entity.Id);

            var jsonBuilder = new StringBuilder();
            Json.JsonSerializer.Serialize(jsonBuilder, entity);

            _requestDispatcher.Dispatch(uri, "PUT", jsonBuilder.ToString());
        }

        public void Delete(T entity)
        {
            string uri = string.Format(@"{0}/{1}.json",
                ResourceUriHelper.GetControllerName(typeof(T)),
                entity.Id);

            _requestDispatcher.Dispatch(uri, "DELETE", string.Empty);
        }
    }
}
