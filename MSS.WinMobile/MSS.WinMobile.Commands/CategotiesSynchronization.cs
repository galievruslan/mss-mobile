using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Synchronizer
{
    public class CategotiesSynchronization : Command<CategoryDto, Category>
    {
        private readonly IWebRepository<CategoryDto> _sourceWebRepository;
        private readonly IStorageRepository<Category> _destinationStorageRepository;
        private readonly DtoTranslator<Category, CategoryDto> _translator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _bathSize;
        private readonly DateTime _updatedAfter;

        public CategotiesSynchronization(
            IWebRepository<CategoryDto> sourceWebRepository,
            IStorageRepository<Category> destinationStorageRepository,
            DtoTranslator<Category, CategoryDto> translator,
            IUnitOfWork unitOfWork,
            int bathSize)
        {
            _sourceWebRepository = sourceWebRepository;
            _destinationStorageRepository = destinationStorageRepository;
            _translator = translator;
            _unitOfWork = unitOfWork;
            _bathSize = bathSize;
        }

        public CategotiesSynchronization(
            IWebRepository<CategoryDto> sourceWebRepository,
            IStorageRepository<Category> destinationStorageRepository,
            DtoTranslator<Category, CategoryDto> translator,
            IUnitOfWork unitOfWork,
            int bathSize,
            DateTime updatedAfter)
            : this(sourceWebRepository, destinationStorageRepository, translator, unitOfWork, bathSize)
        {
            _updatedAfter = updatedAfter;
        }

        public override void Execute()
        {
            try {
                _unitOfWork.BeginTransaction();
                SyncronizeData();
                SynchronizeHierarchy();
                _unitOfWork.Commit();
            }
            catch (Exception) {
                _unitOfWork.Rollback();
                throw;
            }
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
