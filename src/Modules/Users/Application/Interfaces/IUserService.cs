using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Users.Domain.Entities;

namespace inventario.src.Modules.Users.Application.Interfaces;

public interface IUserService
{
    Task RegistrarUsuarioConTareaAsync(string nombre, string email);
    Task ActualizarUsuario(int id, string nuevoNombre, string nuevoEmail);
    Task EliminarUsuario(int id);
    Task<User?> ObtenerUsuarioPorIdAsync(int id);
    Task<IEnumerable<User>> ConsultarUsuariosAsync();
}
