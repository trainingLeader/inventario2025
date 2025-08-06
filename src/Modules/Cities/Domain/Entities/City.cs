using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Regions.Domain.Entties;

namespace inventario.src.Modules.Cities.Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int RegionId { get; set; }
    public Region? Region { get; set; }
}
