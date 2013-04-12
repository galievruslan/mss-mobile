namespace MSS.WinMobile.Domain.Models
{
    public partial class Category
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Category(int id, string name, int parentId)
            : this(id, name)
        {
            ParentId = parentId;
        }

        public string Name { get; private set; }

        public int? ParentId { get; private set; }
    }
}
