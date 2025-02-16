using Microsoft.EntityFrameworkCore;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Server;

namespace New_CRUDTask.ServiceImplementation
{
    public class CategoryService : ICategoryService
    {
        private readonly DbContextServer _db;
        public CategoryService(DbContextServer db)
        {
            _db = db;
        }
        public bool AddCategory(Category category)
        {
            if (_db.Categories.Any(c => c.Name == category.Name))
            {
                return false; ;
            }
            _db.Categories.Add(category);
            _db.SaveChanges();
            return true;
        }

        public void DeleteCategory(int id)
        {
            Category? c = GetCategoryById(id);
            c.IsActive = false;
            _db.SaveChanges();
        }

        public async Task<(List<Category>, int totalcount)> GetCategory(int page, int pageSize)
        {
            int totalcount = _db.Categories.Count();
            return (await _db
                .Categories
                .Where(c => c.IsActive == true)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(c => c.CategoryId)
                .ToListAsync(), totalcount);
        }

        public Category? GetCategoryById(int? id)
        {
            Category? c = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            return c;
        }

        public void UpdateCategory(Category Category)
        {
            _db.Categories.Update(Category);
            _db.SaveChanges();
        }
    }
}
