using EfCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCoreUsecase.Pages.Shared
{
    public class ProductCategoryModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public ProductCategoryModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(string name)
        {
            ProductCategories = _productCategoryApplication.Search(name);
        }
    }
}
