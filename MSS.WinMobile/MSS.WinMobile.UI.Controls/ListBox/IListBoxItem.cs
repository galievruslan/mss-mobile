namespace MSS.WinMobile.UI.Controls.ListBox
{
    public delegate void OnDataNeeded(object sender);

    public delegate void OnSelectNeeded(object sender);

    public interface IListBoxItem<T>
    {
        event OnDataNeeded DataNeeded;
        event OnSelectNeeded SelectNeeded;

        int Index { get; set; }
        T Data { get; set; }

        void Select();
        void UnSelect();
    }
}
