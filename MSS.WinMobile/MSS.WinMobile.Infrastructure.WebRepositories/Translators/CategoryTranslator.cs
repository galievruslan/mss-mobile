﻿using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Translators
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
            return new CategoryProxy(value.Id, value.Name, value.ParentId);
        }
    }
}
