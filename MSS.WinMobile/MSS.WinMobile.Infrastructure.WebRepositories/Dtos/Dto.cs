using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    public class Dto : IModel
    {
        public int Id { get; set; }
        public bool Validity { get; set; }
    }
}
