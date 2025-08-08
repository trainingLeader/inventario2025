using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Countries.Application.Interfaces;
using inventario.src.Modules.Countries.Domain.Entities;
using inventario.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace inventario.src.Modules.Countries.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries // opcional, si quieres traer las tareas asociadas
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Country?>> GetAllAsync() =>
            await _context.Countries.ToListAsync();

        public void Add(Country entity) =>
            _context.Countries.Add(entity);

        public void Remove(Country entity) =>
            _context.Countries.Remove(entity);

        public void Update(Country entity) =>
            _context.SaveChanges();
        public async Task SaveAsync() =>
            await _context.SaveChangesAsync(); // ⬅️ Implementación
        public async Task<IEnumerable<Country>> GetAllWithRegionsAsync() =>
            await _context.Countries.AsNoTracking()
                .Include(c => c.Regions)
                .ToListAsync();
    }
}