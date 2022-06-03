using EfCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCoreUsecase.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        public EditProductCategory Command;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(int id)
        {
            Command = _productCategoryApplication.GetDetails(id);
        }
    }
}
