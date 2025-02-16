using New_CRUDTask.Model;

namespace New_CRUDTask.IServiceImplementation
{
    public interface ICategoryService
    {
        Task<(List<Category>, int totalcount)> GetCategory(int page, int pageSize);
        Category? GetCategoryById(int? id);
        bool AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
