using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Store.App.Helpers;
using Store.App.Models;

namespace Store.App.Services
{
    public class ProductsService :BaseService, IProductsService
    {

        public ProductsService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IOptions<StoreApi> options)
            : base(httpContextAccessor,httpClientFactory,options)
        {
        }

        public async Task<bool> AddAsync(ProductCreateViewModel createproduct)
        {
            var add = await HttpClient.PostAsJsonAsync("/api/v1/products",createproduct);
            if ((int)add.StatusCode == StatusCodes.Status200OK)
            {
                return true;
            }
            return false;
        }

        public async Task<ICollection<ProductViewModel>> GetAllAsync()
        {
            var response = await HttpClient.GetAsync("/api/v1/products");
            var products = await response.Content.ReadAsAsync<ICollection<ProductViewModel>>();

            return products;
        }
    }
}
