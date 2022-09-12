namespace FreeCourse.Services.Basket.Services
{
    using FreeCourse.Services.Basket.Dtos;
    using FreeCourse.Shared.Dtos;
    using System.Threading.Tasks;
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
