
namespace FreeCourse.Services.Catalog.Services
{
    using FreeCourse.Services.Catalog.Dtos;
    using FreeCourse.Services.Catalog.Models;
    using FreeCourse.Shared.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllCategoryAsync();
        Task<Response<CategoryDto>> CreateCategoryAsync(CategoryDto category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);

    }
}
