using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Regions.Domain.Entties;

namespace inventario.src.Modules.Regions.Application.Interfaces;

public interface IRegionRepository
{
    Task<Region?> GetByIdAsync(int id);
    Task<IEnumerable<Region?>> GetAllAsync();
    void Add(Region entity);
    void Remove(Region entity);
    void Update(Region entity);
    Task SaveAsync();
    Task<IEnumerable<Region?>> GetAllWithCountryAsync();
}
