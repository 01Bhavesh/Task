using Microsoft.EntityFrameworkCore;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Server;

namespace New_CRUDTask.ServiceImplementation
{
    public class UserService : IUserService
    {
        private readonly DbContextServer _db;
        public UserService(DbContextServer db)
        {
            _db = db;
        }
        public bool AddUser(User user)
        {
            if (_db.Users.Any(u => u.Gmail == user.Gmail))
            {
                return false;
            }
            _db.Users.Add(user);
            _db.SaveChanges();
            return true;
        }

        public void DeleteUser(int id)
        {
            User? u = GetUserById(id);
            u.IsActive = false;
            _db.SaveChanges();
        }

        public async Task<(List<User>, int totalcount)> GetUser(int page, int pageSize)
        {
            int totalcount = _db.Users.Count();
            return (await _db.Users
                .Where(u => u.IsActive == true)
                .ToListAsync(), totalcount);
        }

        public User? GetUserById(int? id)
        {
            User? u = _db.Users.FirstOrDefault(p => p.UserId == id);
            return u;
        }

        public void UpdateUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }
    }
}
