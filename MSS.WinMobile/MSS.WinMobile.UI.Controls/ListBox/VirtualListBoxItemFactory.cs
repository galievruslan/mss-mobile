namespace MSS.WinMobile.UI.Controls.ListBox
{
    public abstract class VirtualListBoxItemFactory<T>
    {
        public abstract IListBoxItem<T> CreateNewListBoxItem();
    }
}
