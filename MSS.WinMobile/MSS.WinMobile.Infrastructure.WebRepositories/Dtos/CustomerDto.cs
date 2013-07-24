namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/customers.json")]
    public class CustomerDto : Dto
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
