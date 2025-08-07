using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Cities.Domain.Entities;

namespace inventario.src.Modules.Cities.Application.Interfaces;

public interface ICityService
{
    Task<City?> GetCityById(int id);
    Task<IEnumerable<City?>> GetAllCities();
    Task AddCityAsync(City city);
    Task UpdateCityAsync(int id, City city);
    Task RemoveCityAsync(int id);
}
