namespace MSS.WinMobile.UI.Controls.ListBox
{
    public delegate void OnItemDataNeeded(object sender, IListBoxItem item);

    public interface IListBox
    {
        event OnItemDataNeeded ItemDataNeeded;
        int ItemCount { get; set; }
        int SelectedIndex { get; set; }
    }
}
