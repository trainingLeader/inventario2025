using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Regions.Application.Interfaces;
using inventario.src.Modules.Regions.Domain.Entties;
using inventario.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace inventario.src.Modules.Regions.Infrastructure;

public class RegionRepository : IRegionRepository
{
    private readonly AppDbContext _context;

    public RegionRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Region entity)
    {
        _context.Regions.Add(entity);
    }

    public async Task<IEnumerable<Region?>> GetAllAsync() =>
        await _context.Regions.ToListAsync();


    public async Task<Region?> GetByIdAsync(int id)
    {
        return await _context.Regions.FirstOrDefaultAsync(u => u.Id == id);
    }

    public void Remove(Region entity)
    {
        _context.Regions.Remove(entity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public void Update(Region entity) =>
        _context.SaveChanges();
    
    public async Task<IEnumerable<Region?>> GetAllWithCountryAsync()
    {
        return await _context.Regions
            .Include(r => r.Country)
            .ToListAsync();
    }
}

