using Microsoft.EntityFrameworkCore;
using RestManager.Context;
using RestManager.Models;

namespace RestManager.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUserByName(string name)
        {
            IEnumerable<User> users;
            if(!string.IsNullOrEmpty(name)) 
            {
                users = await _context.Users.Where(n => n.Nome.Contains(name)).ToListAsync();
            } else
            {
                users = await GetUsers();
            }
            return users;
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
