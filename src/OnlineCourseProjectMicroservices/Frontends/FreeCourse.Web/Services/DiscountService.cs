﻿using FreeCourse.Shared.Dtos;
using FreeCourse.Web.Models.Discounts;
using FreeCourse.Web.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DiscountViewModel> GetDiscount(string discountCode)
        {
            // [Route("/api/[controller]/[action]/{code}")] Controller da böyle
            var response =await _httpClient.GetAsync($"discounts/GetByCode/{discountCode}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var disCount=  await response.Content.ReadFromJsonAsync<Response<DiscountViewModel>>();
            return disCount.Data;
        }
    }
}
