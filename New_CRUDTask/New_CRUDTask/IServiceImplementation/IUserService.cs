using New_CRUDTask.Model;

namespace New_CRUDTask.IServiceImplementation
{
    public interface IUserService
    {
        Task<(List<User>, int totalcount)> GetUser(int page, int pageSize);
        User? GetUserById(int? id);
        bool AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
