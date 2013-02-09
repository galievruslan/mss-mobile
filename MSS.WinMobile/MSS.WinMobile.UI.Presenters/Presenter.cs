namespace MSS.WinMobile.UI.Presenters
{
    public abstract class Presenter
    {
        protected readonly ILayout Layout;

        protected Presenter(ILayout layout)
        {
            Layout = layout;
        }
    }
}
