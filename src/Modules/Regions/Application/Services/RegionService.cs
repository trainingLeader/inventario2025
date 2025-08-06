using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Regions.Application.Interfaces;
using inventario.src.Modules.Regions.Domain.Entties;
using inventario.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace inventario.src.Modules.Regions.Application.Services;

public class RegionService : IRegionService
{
    private readonly IRegionRepository _regionRepository;

    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public async Task RegistrarRegionConTareaAsync(Region region)
    {
        _regionRepository.Add(region);
        await _regionRepository.SaveAsync();
    }

    public async Task ActualizarRegion(int id, Region region)
    {
        var existingRegion = await _regionRepository.GetByIdAsync(id);
        if (existingRegion != null)
        {
            existingRegion.Name = region.Name;
            _regionRepository.Update(existingRegion);
            await _regionRepository.SaveAsync();
        }
    }

    public async Task EliminarRegion(int id)
    {
        var region = await _regionRepository.GetByIdAsync(id);
        if (region != null)
        {
            _regionRepository.Remove(region);
            await _regionRepository.SaveAsync();
        }
    }

    public async Task<Region?> ObtenerRegionPorIdAsync(int id)
    {
        return await _regionRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Region?>> ConsultarRegionsAsync()
    {
        return await _regionRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Region?>> VerRegionConPais()
    {
        return await _regionRepository.GetAllWithCountryAsync();
    }
}
