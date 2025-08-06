using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.src.Modules.Cities.Domain.Entities;
using inventario.src.Modules.Countries.Domain.Entities;

namespace inventario.src.Modules.Regions.Domain.Entties;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public ICollection<City>? Cities { get; set; }
}
