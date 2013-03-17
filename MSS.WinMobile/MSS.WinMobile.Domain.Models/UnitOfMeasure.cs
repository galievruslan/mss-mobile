namespace MSS.WinMobile.Domain.Models
{
    public partial class UnitOfMeasure
    {
        public UnitOfMeasure(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }
    }
}
