using System;
using System.Collections.Generic;
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
        private readonly CategoryViewModel _selectedViewModel;
        private TreeNode _selectedTreeNode;

        public CategoryLookUpView(IPresentersFactory presentersFactory, 
                                  ILocalizationManager localizationManager,
                                  CategoryViewModel selectedViewModel)
            : base(localizationManager) {
            InitializeComponent();
            
            _presentersFactory = presentersFactory;
            Text = localizationManager.Localization.GetLocalizedValue(Text);
            _selectedViewModel = selectedViewModel;
        }

        private CategoryLookUpPresenter _categoryLookUpPresenter;
        private void CategoryLookUpViewLoad(object sender, EventArgs e) {
            if (_categoryLookUpPresenter == null) {
                _categoryLookUpPresenter = _presentersFactory.CreateCategoryLookUpPresenter(this,
                                                                                            _selectedViewModel);

                BuildTreeViewView();
            }
        }

        private void BuildTreeViewView() {
            var categoryViewModels =
                    new List<CategoryViewModel>(_categoryLookUpPresenter.GetCategories());

            foreach (var categoryViewModel in categoryViewModels) {
                if (categoryViewModel.ParentId == 0) {
                    var treeNode = new TreeNode(categoryViewModel.Name) {
                        Tag = categoryViewModel
                    };

                    if (_selectedViewModel != null && categoryViewModel.Id == _selectedViewModel.Id)
                        _selectedTreeNode = treeNode;

                    FillTreeViewNode(treeNode, categoryViewModels);
                    _categoriesTreeView.Nodes.Add(treeNode);

                    if (_selectedTreeNode != null)
                        _categoriesTreeView.SelectedNode = _selectedTreeNode;
                }
            }
        }

        private void FillTreeViewNode(TreeNode parentTreeNode, IEnumerable<CategoryViewModel> categories) {
            foreach (var categoryViewModel in categories)
            {
                var viewModel = parentTreeNode.Tag as CategoryViewModel;
                if (viewModel != null) {
                    int parentId = viewModel.Id;

                    if (parentId == categoryViewModel.ParentId) {
                        var treeNode = new TreeNode(categoryViewModel.Name)
                        {
                            Tag = categoryViewModel
                        };

                        if (_selectedViewModel != null && categoryViewModel.Id == _selectedViewModel.Id)
                            _selectedTreeNode = treeNode;

                        FillTreeViewNode(treeNode, categories);
                        parentTreeNode.Nodes.Add(treeNode);
                    }
                }
            }
        }

        readonly List<CategoryViewModel> _selectedCategoryViewModels = new List<CategoryViewModel>();
        public IEnumerable<CategoryViewModel> SelectedCategories {
            get {
                TreeNode node = _categoriesTreeView.SelectedNode;
                if (node != null)
                    CollectChildNoodes(node);

                return _selectedCategoryViewModels;
            }
        }

        private void CollectChildNoodes(TreeNode node) {
            _selectedCategoryViewModels.Add(node.Tag as CategoryViewModel);
            foreach (TreeNode childNoode in node.Nodes) {
                CollectChildNoodes(childNoode);
            }
        }
    }
}