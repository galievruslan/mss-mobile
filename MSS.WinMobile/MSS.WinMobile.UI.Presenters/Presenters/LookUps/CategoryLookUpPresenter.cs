using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;
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

        public IEnumerable<CategoryViewModel> GetRootCategories() {
            var categoryRepository = _repositoryFactory.CreateRepository<Category>();
            IEnumerable<Category> categories =
                categoryRepository.Find().Where(new RootCategoriesSpec());

            return categories.Select(category => new CategoryViewModel {
                Id = category.Id, Name = category.Name, ParentId = category.ParentId
            }).ToList();
        }

        public IEnumerable<CategoryViewModel> GetChildCategories(
            CategoryViewModel parentCategoryViewModel) {
            var categoryRepository = _repositoryFactory.CreateRepository<Category>();
            var parentCategory = categoryRepository.GetById(parentCategoryViewModel.Id);
            IEnumerable<Category> categories =
                categoryRepository.Find().Where(new ChildCategoriesSpec(parentCategory));

            return categories.Select(category => new CategoryViewModel {
                Id = category.Id, Name = category.Name, ParentId = category.ParentId
            }).ToList();
        }
    }
}
