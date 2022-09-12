
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

        public async Task<Response<List<CategoryDto>>> GetAllCategoryAsync()
        {
            var list = await _categoryCollection.Find(category => true).ToListAsync(); //db deki Category tablosunu çektik

            //Burada ise category tablosunu CategoryDto listesine mappledik.
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(list), 200);
        }

        public async Task<Response<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {

            var category = await _categoryCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category bulunamadı...", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
