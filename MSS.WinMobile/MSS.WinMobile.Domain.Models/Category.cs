namespace MSS.WinMobile.Domain.Models
{
    public class Category : Model
    {
        public Category(int id, string name, int parentId)
            : base(id)
        {
            Name = name;
            ParentId = parentId;
        }

        public string Name { get; set; }

        public int ParentId { get; set; }
    }
}
