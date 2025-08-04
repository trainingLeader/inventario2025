using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Users.Application.Interfaces;
using inventario.src.Modules.Users.Domain.Entities;
using inventario.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace inventario.src.Modules.Users.Application.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users // opcional, si quieres traer las tareas asociadas
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _context.Users.ToListAsync();

    public void Add(User entity) =>
        _context.Users.Add(entity);

    public void Remove(User entity) =>
        _context.Users.Remove(entity);

    public void Update(User entity) =>
        _context.SaveChanges();
    public async Task SaveAsync() =>
    await _context.SaveChangesAsync(); // ⬅️ Implementación
}
