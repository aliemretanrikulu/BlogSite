

using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entities;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();

    ReturnModel<CategoryResponseDto> GetById(Guid id);

    ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create);

    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest update);

    ReturnModel<CategoryResponseDto> Remove(Guid id);
}
