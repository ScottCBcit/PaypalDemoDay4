﻿
using WebSecurityDay3.Data;
using WebSecurityDay3.Models;


namespace WebSecurityDay3.Repositories
{
    public class ProductRepo
    {

        private ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
