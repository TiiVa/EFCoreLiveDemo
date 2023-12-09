﻿using Common.Models;
using DataAccess;
using DataAccess.Entities;

namespace Common.Services;

public class ProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public List<ProductModel> GetAllProducts()
    {
        return _context.Products.Select(
                                  product => new ProductModel
                                  {
                                      Id = product.Id,
                                      Name = product.Name,
                                      Description = product.Description,
                                      Price = product.Price
                                  }).ToList();
    }

    public ProductModel GetProductById(int id)
    {
        var product = _context.Products.Find(id);
        return new ProductModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }

    public void AddProduct(ProductModel product)
    {
        var a = _context.Products.Add(
                       new Product
                       {
                           Name = product.Name,
                           Description = product.Description,
                           Price = product.Price
                       });
        _context.SaveChanges();
    }

    public void UpdateProduct(ProductModel product)
    {
        var a = _context.Products.Update(
                                  new Product
                                  {
                                      Id = product.Id,
                                      Name = product.Name,
                                      Description = product.Description,
                                      Price = product.Price
                                  });
        _context.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        var product = _context.Products.Find(productId);
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

}