﻿using System;
using System.Linq;
using MSS.WinMobile.Common;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Synchronizer
{
    public class SynchronizationCommand<TS, TD> : Command<bool>
        where TS : Dto
        where TD : Model {
        private readonly IWebRepository<TS> _sourceWebRepository;
        private readonly IStorageRepository<TD> _destinationStorageRepository;
        private readonly DtoTranslator<TD, TS> _translator;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly int _bathSize;
        private readonly DateTime _updatedAfter;

        public SynchronizationCommand(
            IWebRepository<TS> sourceWebRepository,
            IStorageRepository<TD> destinationStorageRepository,
            DtoTranslator<TD, TS> translator,
            IUnitOfWorkFactory unitOfWorkFactory,
            int bathSize) {
            _sourceWebRepository = sourceWebRepository;
            _destinationStorageRepository = destinationStorageRepository;
            _translator = translator;
            _unitOfWorkFactory = unitOfWorkFactory;
            _bathSize = bathSize;
        }

        public SynchronizationCommand(
            IWebRepository<TS> sourceWebRepository,
            IStorageRepository<TD> destinationStorageRepository,
            DtoTranslator<TD, TS> translator,
            IUnitOfWorkFactory unitOfWorkFactory,
            int bathSize,
            DateTime updatedAfter)
            : this(
                sourceWebRepository, destinationStorageRepository, translator, unitOfWorkFactory,
                bathSize) {
            _updatedAfter = updatedAfter;
        }

        public override bool Execute() {

            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                try {
                    unitOfWork.BeginTransaction();
                    int page = 1;
                    TS[] dtos;

                    do {
                        dtos = _updatedAfter != DateTime.MinValue
                                   ? _sourceWebRepository.Find()
                                                         .UpdatedAfter(_updatedAfter)
                                                         .Paged(page, _bathSize)
                                                         .ToArray()
                                   : _sourceWebRepository.Find()
                                                         .Paged(page, _bathSize)
                                                         .ToArray();

                        foreach (var dto in dtos) {
                            var model = _translator.Translate(dto);
                            if (dto.Validity)
                                _destinationStorageRepository.Save(model);
                            else
                                _destinationStorageRepository.Delete(model);
                        }

                        page++;
                    } while (dtos.Length == _bathSize);
                    unitOfWork.Commit();
                }
                catch(Exception) {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            return true;
        }
    }
}
