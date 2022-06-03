﻿namespace EfCore.Domain.ProductAgg;

public interface IProductRepository
{
    Product Get(int id);
    void Create(Product product);
}