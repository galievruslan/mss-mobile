using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps {
    public partial class CategoryLookUpView : LookUpView, ICategoryLookUpView {
        internal CategoryLookUpView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;

        public CategoryLookUpView(IPresentersFactory presentersFactory, ILocalizator localizator,
                                  CategoryViewModel categoryViewModel)
            : base(localizator) {
            _presentersFactory = presentersFactory;
            SelectedCategory = categoryViewModel;
        }

        public CategoryViewModel SelectedCategory { get; private set; }
        private CategoryLookUpPresenter _categoryLookUpPresenter;
        private void CategoryLookUpViewLoad(object sender, EventArgs e) {
            if (_categoryLookUpPresenter == null) {
                _categoryLookUpPresenter = _presentersFactory.CreateCategoryLookUpPresenter(this,
                                                                                            SelectedCategory);

                FillTreeView();
                if (_selectedTreeNode != null)
                    _categoriesTreeView.SelectedNode = _selectedTreeNode;

                _categoriesTreeView.AfterSelect += CategoriesTreeViewAfterSelect;
            }
        }

        void CategoriesTreeViewAfterSelect(object sender, TreeViewEventArgs e) {
            SelectedCategory = e.Node.Tag as CategoryViewModel;
        }

        private TreeNode _selectedTreeNode;
        private void FillTreeView() {
            var categoryViewModels =
                    _categoryLookUpPresenter.GetRootCategories();
            foreach (var categoryViewModel in categoryViewModels) {
                var treeNode = new TreeNode(categoryViewModel.Name) {
                    Tag = categoryViewModel
                };

                if (categoryViewModel.Id == SelectedCategory.Id)
                    _selectedTreeNode = treeNode;

                FillTreeViewNode(treeNode);
                _categoriesTreeView.Nodes.Add(treeNode);

            }
        }

        private void FillTreeViewNode(TreeNode parentTreeNode) {
            IEnumerable<CategoryViewModel> categoryViewModels =
                    _categoryLookUpPresenter.GetChildCategories(parentTreeNode.Tag as CategoryViewModel);
            foreach (var categoryViewModel in categoryViewModels) {
                var treeNode = new TreeNode(categoryViewModel.Name)
                {
                    Tag = categoryViewModel
                };

                if (categoryViewModel.Id == SelectedCategory.Id)
                    _selectedTreeNode = treeNode;

                FillTreeViewNode(treeNode);
                parentTreeNode.Nodes.Add(treeNode);
            }
        }
    }
}