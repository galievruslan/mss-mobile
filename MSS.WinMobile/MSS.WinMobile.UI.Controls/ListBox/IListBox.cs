namespace MSS.WinMobile.UI.Controls.ListBox
{
    public delegate void OnItemDataNeeded(object sender, IListBoxItem item);
    public delegate void OnItemSelected(object sender, IListBoxItem item);

    public interface IListBox
    {
        event OnItemDataNeeded ItemDataNeeded;
        event OnItemSelected ItemSelected;

        int ItemCount { get; set; }
        int SelectedIndex { get; set; }
    }
}
