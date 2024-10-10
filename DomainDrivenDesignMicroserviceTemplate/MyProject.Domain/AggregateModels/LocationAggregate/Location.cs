using MyProject.Domain.AggregateModels.ItemLotAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.AggregateModels.LocationAggregate;

public class Location : Entity, IAggregateRoot
{
    public string LocationId { get; private set; }
    public List<ItemLot> ItemLots { get; private set; } = new List<ItemLot>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Location()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}
