using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCore.Application.Contracts.ProductCategory;
using EfCore.Domain.CategoryAgg;

namespace EfCore.Infrastructure.Efcore.Repository
{
    public class ProductCategoryRepository:IProductCategoryRepository
    {
        private readonly EfContext _context;

        public ProductCategoryRepository(EfContext context)
        {
            _context = context;
        }

        public ProductCategory Get(int id)
        {
            return _context.CategoryProducts.FirstOrDefault(x => x.Id == id);
        }

        public void Create(ProductCategory productCategory)
        {
            _context.CategoryProducts.Add(productCategory);
            saveChange();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _context.CategoryProducts.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }

        public void saveChange()
        {
            _context.SaveChanges();
        }

        public bool Exists(string name)
        {
            return _context.CategoryProducts.Any(x => x.Name == name);
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            var query = _context.CategoryProducts
                .Select(x => new ProductCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreationDate = x.CreationDate.ToString()

                }).ToList();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name)).ToList();
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
