namespace MSS.WinMobile.UI.ViewModel
{
    public interface IValidatable
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <returns>True - valid, else invalid</returns>
        bool Validate();
    }
}
