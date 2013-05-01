using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.ModelTranslators;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.WebRepositories;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Synchronizer
{
    public class CategotiesSynchronization : Command<CategoryDto, Category>
    {
        private readonly WebRepository<CategoryDto> _sourceRepository;
        private readonly SqLiteRepository<Category> _destinationRepository;
        private readonly DtoTranslator<Category, CategoryDto> _translator;
        private readonly int _bathSize;
        private readonly DateTime _updatedAfter;

        public CategotiesSynchronization(
            WebRepository<CategoryDto> sourceRepository,
            SqLiteRepository<Category> destinationRepository,
            DtoTranslator<Category, CategoryDto> translator,
            int bathSize)
        {
            _sourceRepository = sourceRepository;
            _destinationRepository = destinationRepository;
            _translator = translator;
            _bathSize = bathSize;
        }

        public CategotiesSynchronization(
            WebRepository<CategoryDto> sourceRepository,
            SqLiteRepository<Category> destinationRepository,
            DtoTranslator<Category, CategoryDto> translator,
            int bathSize,
            DateTime updatedAfter)
            : this(sourceRepository, destinationRepository, translator, bathSize)
        {
            _updatedAfter = updatedAfter;
        }

        public override void Execute()
        {
            SyncronizeData();
            SynchronizeHierarchy();
        }

        private void SyncronizeData() {
            int page = 1;
            CategoryDto[] dtos;

            do
            {
                dtos = _updatedAfter != DateTime.MinValue
                           ? _sourceRepository.Find().Paged(page, _bathSize).UpdatedAfter(_updatedAfter).ToArray()
                           : _sourceRepository.Find().Paged(page, _bathSize).ToArray();

                foreach (var dto in dtos) {
                    dto.ParentId = 0;
                    var model = _translator.Translate(dto);
                    if (dto.Validity)
                        _destinationRepository.Save(model);
                    else
                        _destinationRepository.Delete(model);
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
                           ? _sourceRepository.Find().Paged(page, _bathSize).UpdatedAfter(_updatedAfter).ToArray()
                           : _sourceRepository.Find().Paged(page, _bathSize).ToArray();

                foreach (var dto in dtos)
                {
                    if (dto.Validity) {
                        var model = _translator.Translate(dto);
                        _destinationRepository.Save(model);
                    }
                }

                page++;
            } while (dtos.Length == _bathSize);
        }
    }
}
