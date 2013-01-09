namespace MSS.WinMobile.UI.ViewModel
{
    public abstract class ViewModel : IValidatable
    {
        protected ErrorCollection Errors;

        protected ViewModel()
        {
            Errors = new ErrorCollection();
        }

        public virtual bool IsDirty { get; protected set; }

        public virtual bool Validate()
        {   
            return Errors.Count == 0;
        }
    }
}
