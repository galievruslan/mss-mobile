namespace MSS.WinMobile.UI.Controls.ListBox
{
    public delegate void OnDataNeeded(object sender);

    public interface IListBoxItem<T> where T : class 
    {
        event OnDataNeeded DataNeeded;

        int Index { get; set; }
        T Data { get; set; }
    }
}
