using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.ModelTranslators;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.WebRepositories;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Synchronizer
{
    public class SynchronizationCommand<TS, TD> : Command<TS, TD>
        where TS : Dto
        where TD : Model
    {
        private readonly WebRepository<TS> _sourceRepository;
        private readonly SqLiteRepository<TD> _destinationRepository;
        private readonly DtoTranslator<TD, TS> _translator;
        private SqLiteUnitOfWork _unitOfWork;
        private readonly int _bathSize;
        private readonly DateTime _updatedAfter;

        public SynchronizationCommand(
            WebRepository<TS> sourceRepository,
            SqLiteRepository<TD> destinationRepository,
            DtoTranslator<TD,TS> translator,
            SqLiteUnitOfWork unitOfWork,
            int bathSize)
        {
            _sourceRepository = sourceRepository;
            _destinationRepository = destinationRepository;
            _translator = translator;
            _unitOfWork = unitOfWork;
            _bathSize = bathSize;
        }

        public SynchronizationCommand(
            WebRepository<TS> sourceRepository,
            SqLiteRepository<TD> destinationRepository,
            DtoTranslator<TD, TS> translator,
            SqLiteUnitOfWork unitOfWork,
            int bathSize,
            DateTime updatedAfter)
            : this(sourceRepository, destinationRepository, translator, unitOfWork, bathSize)
        {
            _updatedAfter = updatedAfter;
        }

        public override void Execute()
        {
            try {
                _unitOfWork.BeginTransaction();
                int page = 1;
                TS[] dtos;

                do {
                    dtos = _updatedAfter != DateTime.MinValue
                               ? _sourceRepository.Find().Paged(page, _bathSize).UpdatedAfter(_updatedAfter).ToArray()
                               : _sourceRepository.Find().Paged(page, _bathSize).ToArray();

                    foreach (var dto in dtos) {
                        var model = _translator.Translate(dto);
                        if (dto.Validity)
                            _destinationRepository.Save(model);
                        else
                            _destinationRepository.Delete(model);
                    }

                    page++;
                } while (dtos.Length == _bathSize);
                _unitOfWork.Commit();
            }
            catch (Exception exception) {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
