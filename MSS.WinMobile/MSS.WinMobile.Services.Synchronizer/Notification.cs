namespace MSS.WinMobile.Services
{
    public class Notification
    {
        public Notification(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
