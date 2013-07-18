using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MSS.WinMobile.Localization;
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

        public CategoryLookUpView(IPresentersFactory presentersFactory, 
                                  ILocalizationManager localizationManager,
                                  CategoryViewModel categoryViewModel)
            : base(localizationManager) {
            InitializeComponent();
            
            _presentersFactory = presentersFactory;
            Text = localizationManager.Localization.GetLocalizedValue(Text);
            SelectedCategory = categoryViewModel;
        }

        public CategoryViewModel SelectedCategory { get; private set; }
        private CategoryLookUpPresenter _categoryLookUpPresenter;
        private void CategoryLookUpViewLoad(object sender, EventArgs e) {
            if (_categoryLookUpPresenter == null) {
                _categoryLookUpPresenter = _presentersFactory.CreateCategoryLookUpPresenter(this,
                                                                                            SelectedCategory);

                BuildTreeViewView();
                if (_selectedTreeNode != null)
                    _categoriesTreeView.SelectedNode = _selectedTreeNode;

                _categoriesTreeView.AfterSelect += CategoriesTreeViewAfterSelect;
            }
        }

        void CategoriesTreeViewAfterSelect(object sender, TreeViewEventArgs e) {
            SelectedCategory = e.Node.Tag as CategoryViewModel;
        }

        private TreeNode _selectedTreeNode;
        private void BuildTreeViewView() {
            var categoryViewModels =
                    new List<CategoryViewModel>(_categoryLookUpPresenter.GetCategories());

            foreach (var categoryViewModel in categoryViewModels) {
                if (categoryViewModel.ParentId == 0) {
                    var treeNode = new TreeNode(categoryViewModel.Name) {
                        Tag = categoryViewModel
                    };

                    if (categoryViewModel.Id == SelectedCategory.Id)
                        _selectedTreeNode = treeNode;

                    FillTreeViewNode(treeNode, categoryViewModels);
                    _categoriesTreeView.Nodes.Add(treeNode);
                }

            }
        }

        private void FillTreeViewNode(TreeNode parentTreeNode, List<CategoryViewModel> categories) {

            foreach (var categoryViewModel in categories) {
                var viewModel = parentTreeNode.Tag as CategoryViewModel;
                if (viewModel != null) {
                    int parentId = viewModel.Id;

                    if (parentId == categoryViewModel.ParentId) {
                        var treeNode = new TreeNode(categoryViewModel.Name)
                        {
                            Tag = categoryViewModel
                        };

                        if (categoryViewModel.Id == SelectedCategory.Id)
                            _selectedTreeNode = treeNode;

                        FillTreeViewNode(treeNode, categories);
                        parentTreeNode.Nodes.Add(treeNode);
                    }
                }
            }
        }
    }
}