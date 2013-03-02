using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Remote.Data;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeCategories : SynchronizationCommand {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeCategories));

        private readonly Server _server;

        public SynchronizeCategories(Server server, ISession session)
            :base(session) {
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
                    var category = new Category
                    {
                        Id = categoryDto.Id,
                        Name = categoryDto.Name,
                    };

                    if (categoryDto.CategoryId != 0)
                        category.ParentId = categoryDto.CategoryId;


                    categories.Add(category);
                }
                SynchronizeEntity(categories);
                categories.Clear();

                pageNumber++;
                categoriesDtos = _server.CategoryServiceService.GetCategories(pageNumber, itemsPerPage);
            }
            return true;
        }
    }
}
