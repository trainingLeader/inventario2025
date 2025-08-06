using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Countries.Domain.Entities;

namespace inventario.src.Modules.Countries.Application.Interfaces;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(int id);
    Task<IEnumerable<Country?>> GetAllAsync();
    void Add(Country entity);
    void Remove(Country entity);
    void Update(Country entity);
    Task SaveAsync();
}
