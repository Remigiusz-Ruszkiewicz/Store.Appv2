using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Store.App.Helpers;
using Store.App.Models;
using Store.App.StoreApiContracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store.App.Services
{
    public class CategoriesService : BaseService,ICategoriesService
    {
        public CategoriesService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IOptions<StoreApi> options)
            : base(httpContextAccessor, httpClientFactory, options)
        {
        }

        public async Task<ICollection<CategoryViewModel>> GetAllAsync()
        {
            var response = await HttpClient.GetAsync("/api/v1/categories");
            var categories = await response.Content.ReadAsAsync<PagedResponse<CategoryResponse>>();
            var categoriesViewModel = categories.Data.Select(x=>new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            });
            return categoriesViewModel.ToList();
        }
    }
}
