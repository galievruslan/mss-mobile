namespace MSS.WinMobile.Domain.Models
{
    public partial class Manager
    {
        public Manager(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }
    }
}
