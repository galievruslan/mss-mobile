﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps {
    public partial class CategoryLookUpView : LookUpView, ICategoryLookUpView {
        public CategoryLookUpView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        public CategoryLookUpView(IPresentersFactory presentersFactory, CategoryViewModel categoryViewModel) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
            SelectedCategory = categoryViewModel;
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        public CategoryViewModel SelectedCategory { get; private set; }
        private CategoryLookUpPresenter _categoryLookUpPresenter;
        private void CategoryLookUpView_Load(object sender, EventArgs e) {
            if (_categoryLookUpPresenter == null) {
                _categoryLookUpPresenter = _presentersFactory.CreateCategoryLookUpPresenter(this,
                                                                                            SelectedCategory);

                FillTreeView();
                if (_selectedTreeNode != null)
                    _categoriesTreeView.SelectedNode = _selectedTreeNode;

                _categoriesTreeView.AfterSelect += _categoriesTreeView_AfterSelect;
            }
        }

        void _categoriesTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
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