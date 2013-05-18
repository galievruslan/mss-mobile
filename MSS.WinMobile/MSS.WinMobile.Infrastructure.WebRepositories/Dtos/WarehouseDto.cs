namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/warehouses.json")]
    public class WarehouseDto : Dto
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
