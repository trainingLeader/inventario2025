using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Cities.Domain.Entities;

namespace inventario.src.Modules.Cities.Application.Interfaces;

public interface ICityService
{
    Task<City?> ObtenerCiudadPorIdAsync(int id);
    Task<IEnumerable<City?>> ConsultarCiudadesAsync();
    Task AgregarCiudadAsync(City city);
    Task ActualizarCiudadAsync(int id, City city);
    Task EliminarCiudadAsync(int id);
}
