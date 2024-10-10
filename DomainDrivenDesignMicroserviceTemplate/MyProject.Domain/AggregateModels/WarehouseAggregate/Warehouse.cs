using MyProject.Domain.AggregateModels.LocationAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.AggregateModels.WarehouseAggregate;

public class Warehouse : Entity, IAggregateRoot
{
    public string WarehouseId { get; private set; } 
    public string WarehouseName { get; private set; }

    public List<Location> Locations = new List<Location>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Warehouse()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}
