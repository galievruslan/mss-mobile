using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Json;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;

namespace MSS.WinMobile.Synchronizer
{
    public class ManagerSynchronization : Command<ManagerDto, Warehouse>
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ManagerSynchronization));

        private readonly IWebServer _webServer;
        private readonly IStorageRepository<Warehouse> _destinationStorageRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly int _bathSize;
        private readonly DateTime _updatedAfter;

        public ManagerSynchronization(
            IWebServer webServer,
            IStorageRepository<Warehouse> destinationStorageRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            int bathSize) {
            _webServer = webServer;
            _destinationStorageRepository = destinationStorageRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
            _bathSize = bathSize;
        }

        public ManagerSynchronization(
            IWebServer webServer,
            IStorageRepository<Warehouse> destinationStorageRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            int bathSize,
            DateTime updatedAfter)
            : this(webServer, destinationStorageRepository, unitOfWorkFactory, bathSize)
        {
            _updatedAfter = updatedAfter;
        }

        public override void Execute()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {

                try {
                    string url;
                    var attribute = (UrlAttribute)typeof(ManagerDto).GetCustomAttributes(typeof(UrlAttribute), true)[0];
                    if (attribute != null)
                        url = attribute.Url;
                    else
                        throw new InvalidOperationException(string.Format("Can't retrieve from web object of type \"{0}\"",
                                                                          typeof(ManagerDto)));

                    var arguments = new Dictionary<string, object>();
                    if (_updatedAfter != DateTime.MinValue) {
                        arguments.Add("updated_at", _updatedAfter.ToString("s"));
                    }

                    HttpWebRequest webRequest = RequestFactory.CreateGetRequest(
                        _webServer.Connect(), url, arguments);
                    string json = _webServer.Connect().Get(webRequest);
                    var managerDto = JsonDeserializer.Deserialize<ManagerDto>(json);

                    unitOfWork.BeginTransaction();
                    if (managerDto != null) {
                        var warehouse =
                            _destinationStorageRepository.GetById(managerDto.DefaultWarehouseId);
                        if (warehouse != null) {
                            warehouse.Default = true;
                            _destinationStorageRepository.Save(warehouse);
                            unitOfWork.Commit();
                        }
                    }
                }
                catch (Exception exception) {
                    Log.Error(exception);
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
