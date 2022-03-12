namespace FreeCourse.Services.Basket.Dtos
{
    using System.Collections.Generic;
    using System.Linq;
    public class BasketDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; } //İndirim oranı
        public List<BasketItemDto> basketItems { get; set; }
        public decimal TotalPrice
        {
            get => basketItems.Sum(x => x.Price * x.Quantity); //Ücret ile kaç tane kurs adedi varsa çarp hepsini topla 
        }
    }
}
