namespace MSS.WinMobile.UI.Controls.ListBox
{
    public delegate void OnDataNeeded(object sender);
    public delegate void OnSelected(object sender);

    public interface IListBoxItem
    {
        event OnDataNeeded DataNeeded;
        event OnSelected Selected;
        
        int Index { get; set; }
        Data Data { get; set; }

        bool IsSelected { get; set; }
    }
}
