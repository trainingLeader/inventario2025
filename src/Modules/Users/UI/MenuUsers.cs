using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Users.Application.Repositories;
using inventario.src.Modules.Users.Application.Services;
using inventario.src.Modules.Users.Domain.Entities;
using inventario.src.Shared.Context;

namespace inventario.src.Modules.Users.UI;

public class MenuUsers
{
    private readonly AppDbContext _context;
    readonly UserRepository repo = null!;
    readonly UserService service = null!;
    public MenuUsers(AppDbContext context)
    {
        _context = context;
        repo = new UserRepository(context);
        service = new UserService(repo);
    }
    public async Task  RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ CRUD ---");
            Console.WriteLine("1. Crear Usuario");
            Console.WriteLine("2. Listar Usuarios");
            Console.WriteLine("3. Actualizar Usuario");
            Console.WriteLine("4. Eliminar Usuario");
            Console.WriteLine("5. Buscar Usuario por ID");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine()!);

            switch (op)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string? nombre = Console.ReadLine();
                    Console.Write("Email: ");
                    string? email = Console.ReadLine();
                    await service.RegistrarUsuarioConTareaAsync(nombre!, email!);
                    Console.WriteLine("✅ Usuario creado.");
                    break;
                case 2:
                    var lista = await service.ConsultarUsuariosAsync();
                    foreach (var u in lista)
                        Console.WriteLine($"ID:{u.Id} | {u.Nombre} - {u.Email}");
                    break;
                case 3:
                    Console.Write("ID a actualizar: ");
                    int idUp = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo nombre: ");
                    string? nuevoNombre = Console.ReadLine();
                    Console.Write("Nuevo email: ");
                    string? nuevoEmail = Console.ReadLine();
                    await service.ActualizarUsuario(idUp, nuevoNombre!, nuevoEmail!);
                    Console.WriteLine("✏️ Actualizado.");
                    break;
                case 4:
                    Console.Write("ID a eliminar: ");
                    int idDel = int.Parse(Console.ReadLine()!);
                    await service.EliminarUsuario(idDel);
                    Console.WriteLine("🗑️ Eliminado.");
                    break;
                case 5:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine()!);
                    User? usuario = await service.ObtenerUsuarioPorIdAsync(id);
                    if (usuario != null)
                        Console.WriteLine($"👤 {usuario.Nombre} - {usuario.Email}");
                    else
                        Console.WriteLine("❌ No encontrado.");
                    break;
                case 6:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("❗ Opción inválida.");
                    break;
            }


        }
    }
}
