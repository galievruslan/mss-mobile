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
        private readonly IEnumerable<CategoryViewModel> _categoryViewModels;

        public CategoryLookUpView(IPresentersFactory presentersFactory, 
                                  ILocalizationManager localizationManager,
                                  IEnumerable<CategoryViewModel> categoryViewModels)
            : base(localizationManager) {
            InitializeComponent();
            
            _presentersFactory = presentersFactory;
            Text = localizationManager.Localization.GetLocalizedValue(Text);
            _categoryViewModels = categoryViewModels;
        }

        private CategoryLookUpPresenter _categoryLookUpPresenter;
        private void CategoryLookUpViewLoad(object sender, EventArgs e) {
            if (_categoryLookUpPresenter == null) {
                _categoryLookUpPresenter = _presentersFactory.CreateCategoryLookUpPresenter(this,
                                                                                            _categoryViewModels);

                BuildTreeViewView();
                _categoriesTreeView.AfterCheck += _categoriesTreeView_AfterCheck;
            }
        }

        private void _categoriesTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Node.Checked) {
                foreach (TreeNode childNode in e.Node.Nodes) {
                    childNode.Checked = true;
                }
            }
            else {
                foreach (TreeNode childNode in e.Node.Nodes) {
                    childNode.Checked = false;
                }
            }
        }

        private readonly List<TreeNode> _treeNoodes = new List<TreeNode>();
        private void BuildTreeViewView() {
            var categoryViewModels =
                    new List<CategoryViewModel>(_categoryLookUpPresenter.GetCategories());

            foreach (var categoryViewModel in categoryViewModels) {
                if (categoryViewModel.ParentId == 0) {
                    var treeNode = new TreeNode(categoryViewModel.Name) {
                        Tag = categoryViewModel
                    };

                    FillTreeViewNode(treeNode, categoryViewModels);
                    _categoriesTreeView.Nodes.Add(treeNode);
                    _treeNoodes.Add(treeNode);
                }
            }

            foreach (var viewModel in _categoryViewModels)
            {
                foreach (var treeNoode in _treeNoodes)
                {
                    var model = treeNoode.Tag as CategoryViewModel;
                    if (model != null && model.Id == viewModel.Id)
                        treeNoode.Checked = true;
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

                        FillTreeViewNode(treeNode, categories);
                        parentTreeNode.Nodes.Add(treeNode);
                        _treeNoodes.Add(treeNode);
                    }
                }
            }
        }
        
        public IEnumerable<CategoryViewModel> SelectedCategories {
            get {
                var selectedCategoryViewModels = new List<CategoryViewModel>(); 
                foreach (var treeNoode in _treeNoodes) {
                    if (treeNoode.Checked) {
                        selectedCategoryViewModels.Add(treeNoode.Tag as CategoryViewModel);
                    }
                }

                return selectedCategoryViewModels;
            }
        }
    }
}