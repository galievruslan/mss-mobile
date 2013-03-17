namespace MSS.WinMobile.Domain.Models
{
    public partial class Status
    {
        public Status(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }
    }
}
