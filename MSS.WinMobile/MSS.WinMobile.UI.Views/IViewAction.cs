namespace MSS.WinMobile.UI.Views
{
    public interface IViewAction {
        string Caption { get; }
        void Do(object sender, System.EventArgs e);
    }
}
