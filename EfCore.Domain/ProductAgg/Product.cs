using EfCore.Domain.CategoryAgg;

namespace EfCore.Domain.ProductAgg
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool IsRemove { get; set; }
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public Product(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
            CreationDate= DateTime.Now;
        }

        public void Edit(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
        }

        public void Remove()
        {
            IsRemove=true;
        }

        public void Restore()
        {
            IsRemove = false;
        }
    }

   
}