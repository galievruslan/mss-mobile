namespace MSS.WinMobile.Common.Observable
{
    public class TextNotification : INotification
    {
        public TextNotification(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
