
namespace FreeCourse.Services.Catalog.Services
{
    using AutoMapper;
    using FreeCourse.Services.Catalog.Dtos;
    using FreeCourse.Services.Catalog.Models;
    using FreeCourse.Services.Catalog.Settings;
    using FreeCourse.Shared.Dtos;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;

        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = db.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task<ResponseDto<List<CategoryDto>>> GetAllCategoryAsync()
        {
            var list = await _categoryCollection.Find(category => true).ToListAsync(); //db deki Category tablosunu çektik

            //Burada ise category tablosunu CategoryDto listesine mappledik.
            return ResponseDto<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(list), 200);
        }

        public async Task<ResponseDto<CategoryDto>> CreateCategoryAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);

            return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<ResponseDto<CategoryDto>> GetByIdAsync(string id)
        {

            var category = await _categoryCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return ResponseDto<CategoryDto>.Fail("Category bulunamadı...", 404);
            }
            return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
