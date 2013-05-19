namespace MSS.WinMobile.Domain.Models
{
    public class Warehouse : Model
    {
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public bool Default { get; set; }
    }
}
