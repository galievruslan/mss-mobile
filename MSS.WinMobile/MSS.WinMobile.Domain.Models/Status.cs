namespace MSS.WinMobile.Domain.Models
{
    public class Status : Model
    {
        public Status(int id, string name)
            :base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
