using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls;
using MSS.WinMobile.UI.Controls.ListBox;

namespace ConsoleTests
{
    public partial class TestForm : Form
    {
        private readonly List<Customer> _customers = new List<Customer>();
        public TestForm()
        {
            for (int i = 0; i < 100; i++)
            {
                _customers.Add(new Customer {Id = i, Name = string.Format("customer #{0}", i)});
            }

            InitializeComponent();
            var virtualListBox = new CustomersListBox();
            virtualListBox.ItemDataNeeded += virtualListBox_ItemDataNeeded;
            Controls.Add(virtualListBox);
            virtualListBox.Dock = DockStyle.Fill;
            virtualListBox.ItemCount = _customers.Count;
        }

        void virtualListBox_ItemDataNeeded(object sender, IListBoxItem<Customer> item)
        {
            item.Data = _customers.Find(customer => customer.Id == item.Index);
        }
    }
}
