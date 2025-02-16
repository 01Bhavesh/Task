using New_CRUDTask.Model;

namespace New_CRUDTask.IServiceImplementation
{
    public interface IProductService
    {
        Task<(List<Product>, int totalcount)> GetProducts(int page, int pageSize);
        Product? GetProductById(int? id);
        bool AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
