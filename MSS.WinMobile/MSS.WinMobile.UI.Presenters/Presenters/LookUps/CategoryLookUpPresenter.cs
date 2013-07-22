using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Presenters.Presenters.LookUps {
    public class CategoryLookUpPresenter : IPresenter<IEnumerable<CategoryViewModel>> {
        private ICategoryLookUpView _categoryLookUpView;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IEnumerable<CategoryViewModel> _categoryViewModels;

        public CategoryLookUpPresenter(ICategoryLookUpView categoryLookUpView,
                                       IRepositoryFactory repositoryFactory,
                                       IEnumerable<CategoryViewModel> categoryViewModels) {
            _categoryLookUpView = categoryLookUpView;
            _repositoryFactory = repositoryFactory;
            _categoryViewModels = categoryViewModels;
        }

        public IEnumerable<CategoryViewModel> Initialize() {
            return _categoryViewModels;
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
