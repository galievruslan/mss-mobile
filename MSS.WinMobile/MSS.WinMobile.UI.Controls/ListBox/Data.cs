namespace MSS.WinMobile.UI.Controls.ListBox
{
    public struct Data
    {
        public Data(int id, string label)
        {
            Id = id;
            Label = label;
        }

        public readonly int Id;
        public readonly string Label;

        public static Data Empty
        {
            get { return new Data(0, string.Empty);}
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Data))
                return false;

            return ((Data) obj).Id == Id;
        }
    }
}
