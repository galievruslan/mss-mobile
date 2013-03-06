namespace MSS.WinMobile.UI.Controls.ListBox
{
    public delegate void OnDataNeeded(object sender);

    public delegate void OnSelectNeeded(object sender);

    public interface IListBoxItem
    {
        event OnDataNeeded DataNeeded;
        event OnSelectNeeded SelectNeeded;
        
        int Index { get; set; }
        string Label { get; set; }
        int Id { get; set; }

        void Select();
        void UnSelect();
    }
}
