using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Countries.Application.Services;
using inventario.src.Modules.Countries.Domain.Entities;
using inventario.src.Modules.Countries.Infrastructure.Repositories;
using inventario.src.Modules.Regions.Domain.Entties;
using inventario.src.Shared.Context;

namespace inventario.src.Modules.Countries.UI;

public class CountryMenu
{
    readonly CountryService _service = null!;

    public CountryMenu(AppDbContext _context)
    {
        var repo = new CountryRepository(_context);
        _service = new CountryService(repo);

    }
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ CRUD Países ---");
            Console.WriteLine("1. Crear País");
            Console.WriteLine("2. Listar Países");
            Console.WriteLine("3. Actualizar País");
            Console.WriteLine("4. Eliminar País");
            Console.WriteLine("5. Buscar País por ID");
            Console.WriteLine("6. Listar Países con Regiones");
            Console.WriteLine("7. Salir");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    Console.Clear();
                    await CrearPaisAsync();
                    break;
                case "2":
                    Console.Clear();
                    await ListarPaisesAsync();
                    break;
                case "3":
                    Console.Clear();
                    await ActualizarPaisAsync();
                    break;
                case "4":
                    Console.Clear();
                    await EliminarPaisAsync();
                    break;
                case "5":
                    Console.Clear();
                    await BuscarPaisPorIdAsync();
                    break;
                case "6":
                    Console.Clear();
                    await ListarConRegionesAsync();
                    break;
                case "7":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
    private async Task CrearPaisAsync()
    {
        Console.Write("Nombre: ");
        var nombre = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return;
        }

        var country = new Country { Name = nombre.Trim() };
        await _service.AgregarPaisAsync(country);
        Console.WriteLine("País creado.");
    }
    private async Task ListarPaisesAsync()
    {
        var paises = await _service.ConsultarPaisesAsync();
        if (!paises.Any())
        {
            Console.WriteLine("No hay países registrados.");
            return;
        }

        Console.WriteLine("Países:");
        foreach (var p in paises)
            Console.WriteLine($"ID: {p.Id} | Nombre: {p.Name}");
    }

    private async Task ActualizarPaisAsync()
    {
        Console.Write("ID a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var existente = await _service.ObtenerPaisPorIdAsync(id);
        if (existente is null)
        {
            Console.WriteLine("País no encontrado.");
            return;
        }

        Console.Write($"Nuevo nombre (actual: {existente.Name}): ");
        var nuevoNombre = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nuevoNombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return;
        }
        else
        {
            existente.Name = nuevoNombre;
        }

        await _service.ActualizarPaisAsync(id, existente);
        Console.WriteLine("País actualizado.");
    }

    private async Task EliminarPaisAsync()
    {
        Console.Write("ID a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var existente = await _service.ObtenerPaisPorIdAsync(id);
        if (existente is null)
        {
            Console.WriteLine("País no encontrado.");
            return;
        }

        await _service.EliminarPaisAsync(id);
        Console.WriteLine("🗑️ País eliminado.");
    }

    private async Task BuscarPaisPorIdAsync()
    {
        Console.Write("ID: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var pais = await _service.ObtenerPaisPorIdAsync(id);
        if (pais is null)
        {
            Console.WriteLine("No encontrado.");
            return;
        }

        Console.WriteLine($"País: ID={pais.Id} | Nombre={pais.Name}");
    }
    private async Task ListarConRegionesAsync()
    {
        var paises = await _service.ConsultarPaisesConRegionesAsync();
        if (!paises.Any()) { Console.WriteLine("Sin países."); return; }

        foreach (var pais in paises)
        {
            Console.WriteLine($"🌎 País: {pais.Name}");
            Console.WriteLine($"Listado de Regiones");
            foreach (var r in pais.Regions ?? new HashSet<Region>())
                Console.WriteLine($"{r.Name}");
        }
        Console.ReadKey();
    }
}
