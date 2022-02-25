
namespace FreeCourse.Services.Catalog.Services
{
    using FreeCourse.Services.Catalog.Dtos;
    using FreeCourse.Services.Catalog.Models;
    using FreeCourse.Shared.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICategoryService
    {
        Task<ResponseDto<List<CategoryDto>>> GetAllCategoryAsync();
        Task<ResponseDto<CategoryDto>> CreateCategoryAsync(Category category);
        Task<ResponseDto<CategoryDto>> GetByIdAsync(string id);

    }
}
