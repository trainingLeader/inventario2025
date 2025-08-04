using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Users.Application.Interfaces;
using inventario.src.Modules.Users.Domain.Entities;

namespace inventario.src.Modules.Users.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }
    public Task<IEnumerable<User>> ConsultarUsuariosAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task RegistrarUsuarioConTareaAsync(string nombre, string email)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(u => u.Email == email))
            throw new Exception("El usuario ya existe.");

        var user = new User
        {
            Nombre = nombre,
            Email = email,
        };

        _repo.Add(user);
        _repo.Update(user); // puede omitirse si Add guarda en memoria
    }
    public async Task ActualizarUsuario(int id, string nuevoNombre, string nuevoEmail)
    {
        var user = await _repo.GetByIdAsync(id);

        if (user == null)
            throw new Exception($"❌ Usuario con ID {id} no encontrado.");

        user.Nombre = nuevoNombre;
        user.Email = nuevoEmail;

        _repo.Update(user);
        await _repo.SaveAsync();
    }

    public async Task EliminarUsuario(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null)
            throw new Exception($"❌ Usuario con ID {id} no encontrado.");
        _repo.Remove(user);
        await _repo.SaveAsync();
    }

    public async Task<User?> ObtenerUsuarioPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
}
