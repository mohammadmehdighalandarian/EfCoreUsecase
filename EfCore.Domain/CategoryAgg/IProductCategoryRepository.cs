using EfCore.Application.Contracts.ProductCategory;

namespace EfCore.Domain.CategoryAgg;

public interface IProductCategoryRepository
{
    ProductCategory Get(int id);
    void Create(ProductCategory productCategory);
    EditProductCategory GetDetails(int id);
    List<ProductCategoryViewModel> Search(string name);
    void saveChange();
    bool Exists(string name);
}