using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Countries.Application.Services;
using inventario.src.Modules.Countries.Domain.Entities;
using inventario.src.Modules.Countries.Infrastructure.Repositories;
using inventario.src.Shared.Context;

namespace inventario.src.Modules.Countries.UI;

public class CountryMenu
{
    private readonly AppDbContext _context;
    readonly CountryRepository repo = null!;
    readonly CountryService service = null!;

    public CountryMenu(AppDbContext _context)
    {
        this._context = _context;
        repo = new CountryRepository(_context);
        service = new CountryService(repo);

    }
    public async Task  RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ CRUD ---");
            Console.WriteLine("1. Crear Pais");
            Console.WriteLine("2. Listar Paises");
            Console.WriteLine("3. Actualizar Pais");
            Console.WriteLine("4. Eliminar Pais");
            Console.WriteLine("5. Buscar Pais por ID");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine()!);

            switch (op)
            {
                case 1:
                    Country myCountry = new Country();
                    Console.Write("Nombre: ");
                    myCountry.Name = Console.ReadLine()!;
                    await service.AgregarPaisAsync(myCountry);
                    Console.WriteLine("✅ Usuario creado.");
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
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
