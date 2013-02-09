namespace MSS.WinMobile.UI.Controls.ListBox
{
    public delegate void OnItemDataNeeded<T>(object sender, IListBoxItem<T> item) where T : class;

    public interface IListBox<T> where T : class 
    {
        event OnItemDataNeeded<T> ItemDataNeeded;
        int ItemCount { get; set; }
    }
}
