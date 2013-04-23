namespace MSS.WinMobile.Domain.Models
{
    public class Category : Model
    {
        public string Name { get; protected set; }
        public int ParentId { get; protected set; }
    }
}
