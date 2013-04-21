using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Server.Dtos;

namespace MSS.WinMobile.Infrastructure.Server.Translators
{
    public class CategoryTranslator : DtoTranslator<Category, CategoryDto>
    {
        protected override CategoryDto ModelToDto(Category value)
        {
            var categoryDto = new CategoryDto {Id = value.Id, Name = value.Name, ParentId = value.ParentId};
            return categoryDto;
        }

        protected override Category DtoToModel(CategoryDto value)
        {
            return new Category(value.Id, value.Name, value.ParentId);
        }
    }
}
