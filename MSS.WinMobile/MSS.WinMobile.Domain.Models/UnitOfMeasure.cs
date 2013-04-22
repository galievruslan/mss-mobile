namespace MSS.WinMobile.Domain.Models
{
    public class UnitOfMeasure : Model
    {
        public UnitOfMeasure(int id, string name)
            :base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
