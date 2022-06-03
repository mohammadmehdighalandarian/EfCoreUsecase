using System.Net.Http.Headers;
using EfCore.Domain.CategoryAgg;
using EfCore.Domain.ProductAgg;
using EfCore.Infrastructure.Efcore.Mapping;
using Microsoft.EntityFrameworkCore;


namespace EfCore.Infrastructure.Efcore
{
    public class EfContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> CategoryProducts { get; set; }

        public EfContext(DbContextOptions<EfContext>options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductMapping());
            //modelBuilder.ApplyConfiguration(new CategoryProductMapping());

            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
            
        }

    }
}