using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Countries.Domain.Entities;

namespace inventario.src.Modules.Countries.Application.Interfaces;

public interface ICountryService
{
    Task<Country?> ObtenerPaisPorIdAsync(int id);
    Task<IEnumerable<Country?>> ConsultarPaisesAsync();
    Task AgregarPaisAsync(string name);
    Task ActualizarPaisAsync(int id, string nuevoNombre);
    Task EliminarPaisAsync(int id);
    Task<Country?> ObtenerUsuarioPorIdAsync(int id);

}
