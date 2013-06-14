using System;
using System.Linq;
using MSS.WinMobile.Common;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Synchronizer
{
    public class CategotiesSynchronization : Command<bool>
    {
        private readonly IWebRepository<CategoryDto> _sourceWebRepository;
        private readonly IStorageRepository<Category> _destinationStorageRepository;
        private readonly DtoTranslator<Category, CategoryDto> _translator;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly int _bathSize;
        private readonly DateTime _updatedAfter;

        public CategotiesSynchronization(
            IWebRepository<CategoryDto> sourceWebRepository,
            IStorageRepository<Category> destinationStorageRepository,
            DtoTranslator<Category, CategoryDto> translator,
            IUnitOfWorkFactory unitOfWorkFactory,
            int bathSize)
        {
            _sourceWebRepository = sourceWebRepository;
            _destinationStorageRepository = destinationStorageRepository;
            _translator = translator;
            _unitOfWorkFactory = unitOfWorkFactory;
            _bathSize = bathSize;
        }

        public CategotiesSynchronization(
            IWebRepository<CategoryDto> sourceWebRepository,
            IStorageRepository<Category> destinationStorageRepository,
            DtoTranslator<Category, CategoryDto> translator,
            IUnitOfWorkFactory unitOfWorkFactory,
            int bathSize,
            DateTime updatedAfter)
            : this(sourceWebRepository, destinationStorageRepository, translator, unitOfWorkFactory, bathSize)
        {
            _updatedAfter = updatedAfter;
        }

        public override bool Execute()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                try {
                    unitOfWork.BeginTransaction();
                    SyncronizeData();
                    SynchronizeHierarchy();
                    unitOfWork.Commit();
                }
                catch (Exception) {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            return true;
        }

        private void SyncronizeData() {
            int page = 1;
            CategoryDto[] dtos;

            do
            {
                dtos = _updatedAfter != DateTime.MinValue
                           ? _sourceWebRepository.Find().UpdatedAfter(_updatedAfter).Paged(page, _bathSize).ToArray()
                           : _sourceWebRepository.Find().Paged(page, _bathSize).ToArray();

                foreach (var dto in dtos) {
                    dto.ParentId = 0;
                    var model = _translator.Translate(dto);
                    if (dto.Validity)
                        _destinationStorageRepository.Save(model);
                    else
                        _destinationStorageRepository.Delete(model);
                }

                page++;
            } while (dtos.Length == _bathSize);
        }

        private void SynchronizeHierarchy() {
            int page = 1;
            CategoryDto[] dtos;

            do
            {
                dtos = _updatedAfter != DateTime.MinValue
                           ? _sourceWebRepository.Find().UpdatedAfter(_updatedAfter).Paged(page, _bathSize).ToArray()
                           : _sourceWebRepository.Find().Paged(page, _bathSize).ToArray();

                foreach (var dto in dtos)
                {
                    if (dto.Validity) {
                        var model = _translator.Translate(dto);
                        _destinationStorageRepository.Save(model);
                    }
                }

                page++;
            } while (dtos.Length == _bathSize);
        }
    }
}
