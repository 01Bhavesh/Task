using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Server;

namespace New_CRUDTask.ServiceImplementation
{
    public class ProductService : IProductService
    {
        private readonly DbContextServer _db;
        public ProductService(DbContextServer db)
        {
            _db = db;
        }
        public bool AddProduct(Product product)
        {
            if (_db.Products.Any(p => p.ProductName == product.ProductName))
            {
                return false; ;
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            return true;
        }

        public void DeleteProduct(int id)
        {
            Product? p = GetProductById(id);
            p.IsActive = false;
            _db.SaveChanges();
        }

        public Product? GetProductById(int? id)
        {
            Product? p = _db.Products.FirstOrDefault(p => p.ProductId == id);
            return p;
        }

        public async Task<(List<Product>, int totalcount)> GetProducts(int page, int pageSize)
        {
            int totalcount = _db.Products.Count();
            return (await _db.Products
                .Where(p => p.IsActive == true)
                .Include(p => p.Categories)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync(), totalcount);// while using include method first it will
                                                           // include all data then check condition on
                                                           // product, if product isactive or not.
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }
    }
}
