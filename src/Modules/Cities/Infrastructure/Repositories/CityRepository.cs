using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Cities.Application.Interfaces;
using inventario.src.Modules.Cities.Domain.Entities;
using inventario.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace inventario.src.Modules.Cities.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;
         public CityRepository(AppDbContext context)
        {
            _context = context;
        }       
        public void Add(City city)
        {
            _context.Cities.Add(city);
        }

        public async Task<IEnumerable<City?>> GetAllAsync() => await _context.Cities.ToListAsync();

        public async Task<City?> GetByIdAsync(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(City entity) => _context.Cities.Remove(entity);

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public void Update(City entity) => _context.SaveChanges();
    }
}