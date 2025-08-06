using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Cities.Application.Interfaces;
using inventario.src.Modules.Cities.Domain.Entities;

namespace inventario.src.Modules.Cities.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository regionRepository)
    {
        _cityRepository = regionRepository;
    }

    public async Task ActualizarCiudadAsync(int id, City city)
    {
        var existingRegion = await _cityRepository.GetByIdAsync(id);
        if (existingRegion != null)
        {
            existingRegion.Name = city.Name;
            _cityRepository.Update(existingRegion);
            await _cityRepository.SaveAsync();
        }
    }

    public async Task AgregarCiudadAsync(City city)
    {
        _cityRepository.Add(city);
        await _cityRepository.SaveAsync();
    }

    public async Task<IEnumerable<City?>> ConsultarCiudadesAsync()
    {
        return await _cityRepository.GetAllAsync();
    }

    public async Task EliminarCiudadAsync(int id)
    {
        var region = await _cityRepository.GetByIdAsync(id);
        if (region != null)
        {
            _cityRepository.Remove(region);
            await _cityRepository.SaveAsync();
        }
    }

    public async Task<City?> ObtenerCiudadPorIdAsync(int id)
    {
        return await _cityRepository.GetByIdAsync(id);
    }
}
