namespace MSS.WinMobile.UI.Controls.ListBox
{
    public delegate void OnItemDataNeeded<T>(object sender, IListBoxItem<T> item);

    public interface IListBox<T>
    {
        event OnItemDataNeeded<T> ItemDataNeeded;
        int ItemCount { get; set; }
        int SelectedIndex { get; set; }
    }
}
