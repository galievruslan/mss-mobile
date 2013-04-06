using System;
using System.Linq;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeCategories : Command<bool>
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeCategories));

        private readonly Server _server;

        public SynchronizeCategories(Server server){
            _server = server;
        }

        protected override bool Execute() {
            var categories = new List<Category>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var categoriesDtos = _server.CategoryServiceService.GetCategories(pageNumber, itemsPerPage);
            while (categoriesDtos.Length > 0)
            {
                foreach (var categoryDto in categoriesDtos)
                {
                    var category = categoryDto.CategoryId == 0
                                       ? new Category(categoryDto.Id, categoryDto.Name)
                                       : new Category(categoryDto.Id, categoryDto.Name, categoryDto.CategoryId);


                    categories.Add(category);
                }

                if (categories.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var category in categories) {
                            category.Create();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                categories.Clear();

                pageNumber++;
                categoriesDtos = _server.CategoryServiceService.GetCategories(pageNumber, itemsPerPage);
            }
            return true;
        }
    }
}
