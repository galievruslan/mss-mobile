using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Presenters.Presenters.LookUps {
    public class CategoryLookUpPresenter : IPresenter<CategoryViewModel> {
        private ICategoryLookUpView _categoryLookUpView;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly CategoryViewModel _categoryViewModel;

        public CategoryLookUpPresenter(ICategoryLookUpView categoryLookUpView,
                                       IRepositoryFactory repositoryFactory,
                                       CategoryViewModel categoryViewModel) {
            _categoryLookUpView = categoryLookUpView;
            _repositoryFactory = repositoryFactory;
            _categoryViewModel = categoryViewModel;
        }

        public CategoryViewModel Initialize() {
            return _categoryViewModel;
        }

        public IEnumerable<CategoryViewModel> GetCategories() {
            var categoryRepository = _repositoryFactory.CreateRepository<Category>();
            IEnumerable<Category> categories = categoryRepository.Find();

            return categories.Select(category => new CategoryViewModel {
                Id = category.Id, Name = category.Name, ParentId = category.ParentId
            }).ToList();
        }
    }
}
