

using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entities;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();

    ReturnModel<CategoryResponseDto> GetById(Guid id);

    ReturnModel<Category> Add(CategoryResponseDto create);

    ReturnModel<Category> Update(CategoryResponseDto update);

    ReturnModel<CategoryResponseDto> Remove(Guid id);
}
