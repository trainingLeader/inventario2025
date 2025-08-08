using inventario.src.Modules.Countries.UI;
using inventario.src.Modules.Users.Application.Repositories;
using inventario.src.Modules.Users.Application.Services;
using inventario.src.Modules.Users.UI;
using inventario.src.Shared.Helpers;

var context = DbContextFactory.Create();


bool salir = false;
while (!salir)
{
    Console.Clear();
    Console.WriteLine("\n--- MENÚ CRUD ---");
    Console.WriteLine("1. Administrar Usuarios");
    Console.WriteLine("2. Administrar Paises");
    Console.WriteLine("3. Salir");
    Console.Write("Opción: ");
    int opm = int.Parse(Console.ReadLine()!);

    switch (opm)
    {
        case 1:
            await new MenuUsers(context).RenderMenu();
            break;
        case 2:
            await new CountryMenu(context).RenderMenu();
            break;
        case 3:
            salir = true;
            break;
        default:
            Console.WriteLine("❗ Opción inválida.");
            break;
    }
}