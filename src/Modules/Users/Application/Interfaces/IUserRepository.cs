using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Users.Domain.Entities;

namespace inventario.src.Modules.Users.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User?>> GetAllAsync();
    void Add(User entity);
    void Remove(User entity);
    void Update(User entity);
    Task SaveAsync(); 
}
