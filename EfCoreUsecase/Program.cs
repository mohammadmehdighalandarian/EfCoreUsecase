using EfCore.Application;
using EfCore.Application.Contracts.ProductCategory;
using EfCore.Domain.CategoryAgg;
using EfCore.Infrastructure.Efcore;
using EfCore.Infrastructure.Efcore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

builder.Services.AddControllersWithViews();
var config = builder.Configuration.GetConnectionString("EfcoreDb");
builder.Services.AddDbContext<EfContext>(x => x.UseSqlServer(config));
builder.Services.AddRazorPages();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
