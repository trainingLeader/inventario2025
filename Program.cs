using inventario.src.Modules.Users.Application.Repositories;
using inventario.src.Modules.Users.Application.Services;
using inventario.src.Shared.Helpers;

var context = DbContextFactory.Create();
var repo = new UserRepository(context);
var service = new UserService(repo);

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
    var op = Console.ReadLine();

    switch (op)
    {
        case "1":
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            await service.RegistrarUsuarioConTareaAsync(nombre!, email!);
            Console.WriteLine("✅ Usuario creado.");
            break;

        case "2":
            var lista = await service.ConsultarUsuariosAsync();
            foreach (var u in lista)
                Console.WriteLine($"ID:{u.Id} | {u.Nombre} - {u.Email}");
            break;

        case "3":
            Console.Write("ID a actualizar: ");
            var idUp = int.Parse(Console.ReadLine()!);
            Console.Write("Nuevo nombre: ");
            var nuevoNombre = Console.ReadLine();
            Console.Write("Nuevo email: ");
            var nuevoEmail = Console.ReadLine();
            await service.ActualizarUsuario(idUp, nuevoNombre!, nuevoEmail!);
            Console.WriteLine("✏️ Actualizado.");
            break;
        case "4":
            Console.Write("ID a eliminar: ");
            var idDel = int.Parse(Console.ReadLine()!);
            await service.EliminarUsuario(idDel);
            Console.WriteLine("🗑️ Eliminado.");
            break;
        case "5":
            Console.Write("ID: ");
            var id = int.Parse(Console.ReadLine()!);
            var usuario = await service.ObtenerUsuarioPorIdAsync(id);
            if (usuario != null)
                Console.WriteLine($"👤 {usuario.Nombre} - {usuario.Email}");
            else
                Console.WriteLine("❌ No encontrado.");
            break;
        case "6":
            salir = true;
            break;

        default:
            Console.WriteLine("❗ Opción inválida.");
            break;
    }
}