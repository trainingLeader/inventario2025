using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario.src.Modules.Countries.Domain.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
