using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Cities.Domain.Entities;

namespace inventario.src.Modules.Cities.Application.Interfaces
{
    public interface ICityRepository
    {
        Task<City?> GetByIdAsync(int id);
        Task<IEnumerable<City?>> GetAllAsync();
        void Add(City entity);
        void Remove(City entity);
        void Update(City entity);
        Task SaveAsync();
    }
}