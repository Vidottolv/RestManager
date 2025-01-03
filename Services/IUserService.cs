﻿using RestManager.Models;

namespace RestManager.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUserByName(string name);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
