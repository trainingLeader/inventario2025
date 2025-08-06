using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Regions.Domain.Entties;
using inventario.src.Shared.Context;

namespace inventario.src.Modules.Regions.Application.Interfaces;

public interface IRegionService
{
    Task RegistrarRegionConTareaAsync(Region region);
    Task ActualizarRegion(int id, Region region);
    Task EliminarRegion(int id);
    Task<Region?> ObtenerRegionPorIdAsync(int id);
    Task<IEnumerable<Region?>> ConsultarRegionsAsync();
    Task<IEnumerable<Region?>> VerRegionConPais();
    

}
