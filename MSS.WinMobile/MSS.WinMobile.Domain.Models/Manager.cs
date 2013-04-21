namespace MSS.WinMobile.Domain.Models
{
    public class Manager : Model
    {
        public Manager(int id, string name)
            :base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }

        //public Order NewOrder(RoutePoint routePoint)
        //{
        //    return new Order(routePoint);
        //}
    }
}
