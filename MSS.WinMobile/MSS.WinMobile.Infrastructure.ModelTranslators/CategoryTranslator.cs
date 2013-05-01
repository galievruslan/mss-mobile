using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class CategoryTranslator : DtoTranslator<Category, CategoryDto>
    {
        public override Category Translate(CategoryDto source)
        {
            return new CategoryProxy
            {
                Id = source.Id,
                Name = source.Name,
                ParentId = source.ParentId != null ? (int)source.ParentId : 0
            };
        }
    }
}
