namespace MSS.WinMobile.Infrastructure.WebRepositories.Utilites
{
    public class CsrfTokenContainer
    {
        public const string CSRF_TOKEN_TAG_NAME = "csrf-token";
        public const string CSRF_TOKEN_VALUE_ATTRIBUTE = "content";

        public string CsrfToken { get; private set; }

        public void SetCsrfToken(string csrfToken)
        {
            CsrfToken = csrfToken;
        }
    }
}
