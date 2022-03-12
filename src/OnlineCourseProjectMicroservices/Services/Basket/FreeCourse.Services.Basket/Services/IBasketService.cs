namespace FreeCourse.Services.Basket.Services
{
    using FreeCourse.Services.Basket.Dtos;
    using FreeCourse.Shared.Dtos;
    using System.Threading.Tasks;
    public interface IBasketService
    {
        Task<ResponseDto<BasketDto>> GetBasket(string userId);
        Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<ResponseDto<bool>> Delete(string userId);
    }
}
