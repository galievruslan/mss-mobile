using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Synchronizer
{
    public class MyShippingAddressesSynchronization : Command<MyShippingAddressDto, ShippingAddress>
    {
        private readonly IWebRepository<MyShippingAddressDto> _sourceWebRepository;
        private readonly IStorageRepository<ShippingAddress> _destinationStorageRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly int _bathSize;
        private readonly DateTime _updatedAfter;

        public MyShippingAddressesSynchronization(
            IWebRepository<MyShippingAddressDto> sourceWebRepository,
            IStorageRepository<ShippingAddress> destinationStorageRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            int bathSize)
        {
            _sourceWebRepository = sourceWebRepository;
            _destinationStorageRepository = destinationStorageRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
            _bathSize = bathSize;
        }

        public MyShippingAddressesSynchronization(
            IWebRepository<MyShippingAddressDto> sourceWebRepository,
            IStorageRepository<ShippingAddress> destinationStorageRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            int bathSize,
            DateTime updatedAfter)
            : this(sourceWebRepository, destinationStorageRepository, unitOfWorkFactory, bathSize)
        {
            _updatedAfter = updatedAfter;
        }

        public override void Execute()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {

                try {
                    unitOfWork.BeginTransaction();
                    int page = 1;
                    MyShippingAddressDto[] dtos;

                    do {
                        dtos = _updatedAfter != DateTime.MinValue
                                   ? _sourceWebRepository.Find()
                                                         .UpdatedAfter(_updatedAfter)
                                                         .Paged(page, _bathSize)
                                                         .ToArray()
                                   : _sourceWebRepository.Find().Paged(page, _bathSize).ToArray();

                        foreach (var dto in dtos) {
                            ShippingAddress shippingAddress =
                                _destinationStorageRepository.GetById(dto.ShippingAddressId);
                            shippingAddress.Mine = dto.Validity;
                            _destinationStorageRepository.Save(shippingAddress);
                        }

                        page++;
                    } while (dtos.Length == _bathSize);
                    unitOfWork.Commit();
                }
                catch (Exception) {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
