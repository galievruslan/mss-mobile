namespace MSS.WinMobile.Domain.Models
{
    public class PriceList : Model
    {
        public PriceList(int id, string name)
            :base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
