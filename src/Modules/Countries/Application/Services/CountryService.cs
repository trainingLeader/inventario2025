using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Countries.Application.Interfaces;
using inventario.src.Modules.Countries.Domain.Entities;

namespace inventario.src.Modules.Countries.Application.Services;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task ActualizarPaisAsync(int id, Country country)
    {
        var existingRegion = await _countryRepository.GetByIdAsync(id);
        if (existingRegion != null)
        {
            existingRegion.Name = country.Name;
            _countryRepository.Update(existingRegion);
            await _countryRepository.SaveAsync();
        }
    }

    public async Task AgregarPaisAsync(Country country)
    {
        _countryRepository.Add(country);
        await _countryRepository.SaveAsync();
    }

    public async Task<IEnumerable<Country?>> ConsultarPaisesAsync()
    {
        return await _countryRepository.GetAllAsync();
    }

    public async Task EliminarPaisAsync(int id)
    {
        var region = await _countryRepository.GetByIdAsync(id);
        if (region != null)
        {
            _countryRepository.Remove(region);
            await _countryRepository.SaveAsync();
        }
    }

    public async Task<Country?> ObtenerPaisPorIdAsync(int id)
    {
        return await _countryRepository.GetByIdAsync(id);
    }
        public async Task<IEnumerable<Country>> ConsultarPaisesConRegionesAsync()
    {
        return await _countryRepository.GetAllWithRegionsAsync();
    }

}
