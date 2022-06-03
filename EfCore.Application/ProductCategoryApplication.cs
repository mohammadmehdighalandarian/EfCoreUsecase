using EfCore.Application.Contracts.ProductCategory;
using EfCore.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Application
{
    public class ProductCategoryApplication: IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public void Create(CreateProductCategory command)
        {
            if (_productCategoryRepository.Exists(command.Name))
            {
                return;
            }

            var productCategory = new ProductCategory(command.Name);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.saveChange();
        }

        public void Edit(EditProductCategory Command)
        {
            var productCategory = _productCategoryRepository.Get(Command.Id);
            if (productCategory == null)
                return;

            productCategory.Edit(Command.Name);
            _productCategoryRepository.saveChange();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            return _productCategoryRepository.Search(name);
        }
    }
}
