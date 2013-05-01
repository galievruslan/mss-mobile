using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.WebRepositories;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Synchronizer
{
    public class MyShippingAddressesSynchronization : Command<MyShippingAddressDto, ShippingAddress>
    {
        private readonly WebRepository<MyShippingAddressDto> _sourceRepository;
        private readonly SQLiteRepository<ShippingAddress> _destinationRepository;
        private readonly int _bathSize;
        private readonly DateTime _updatedAfter;

        public MyShippingAddressesSynchronization(
            WebRepository<MyShippingAddressDto> sourceRepository,
            SQLiteRepository<ShippingAddress> destinationRepository,
            int bathSize)
        {
            _sourceRepository = sourceRepository;
            _destinationRepository = destinationRepository;
            _bathSize = bathSize;
        }

        public MyShippingAddressesSynchronization(
            WebRepository<MyShippingAddressDto> sourceRepository,
            SQLiteRepository<ShippingAddress> destinationRepository,
            int bathSize,
            DateTime updatedAfter)
            : this(sourceRepository, destinationRepository, bathSize)
        {
            _updatedAfter = updatedAfter;
        }

        public override void Execute()
        {
            int page = 1;
            MyShippingAddressDto[] dtos;

            do
            {
                dtos = _updatedAfter != DateTime.MinValue
                           ? _sourceRepository.Find().Paged(page, _bathSize).UpdatedAfter(_updatedAfter).ToArray()
                           : _sourceRepository.Find().Paged(page, _bathSize).ToArray();

                foreach (var dto in dtos)
                {
                    ShippingAddress shippingAddress = _destinationRepository.GetById(dto.ShippingAddressId);
                    shippingAddress.Mine = dto.Validity;
                    _destinationRepository.Save(shippingAddress);
                }

                page++;
            } while (dtos.Length == _bathSize);
        }
    }
}
