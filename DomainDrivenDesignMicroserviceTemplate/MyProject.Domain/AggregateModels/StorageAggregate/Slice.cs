using ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.StorageAggregate;

public class Slice
{
    public int ShelfId { get; private set; }
    public uint RowId { get; private set; }
    public uint CellId { get; private set; }
    public uint Id { get; private set; }
    public uint NumberOfLevels => Slots.Max(s => s.LevelId);
    public uint NumberOfColumns => Slots.Max(s => s.Id);
    public Item? Item { get; private set; }
    public List<Slot> Slots { get; private set; }
    public uint FreeSlot => (uint)(this.Slots.Count - this.Slots.Count(s => s.Container is not null));

    public Slice(int shelfId, uint rowId, uint cellId, uint id)
    {
        ShelfId = shelfId;
        RowId = rowId;
        CellId = cellId;
        Id = id;
        Slots = new List<Slot>();
    }

    public void SetItem(Item item)
    {
        if (Slots.Any(s => s.Container is not null))
        {
            throw new WarehouseDomainException($"The cell slice with id {Id} still contain container(s). Please clear the slice before setting its item type.");
        }

        Item = item;
    }

    public void AddContainers(IEnumerable<Container> containers)
    {
        if (FreeSlot < containers.Count())
        {
            throw new WarehouseDomainException($"The cell slice with ID {Id} has insufficient space.");
        }

        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }

    public void AddContainer(Container container)
    {
        for(uint levelId = 1; levelId <= this.NumberOfLevels; levelId++)
        {
            if (!IsLevelFull(levelId))
            {
                for (uint columnId = 1; columnId <= this.NumberOfColumns; columnId++)
                {
                    var slot = FindSlot(levelId, columnId);
                    if (slot.Container is null)
                    {
                        slot.SetContainer(container);
                        return;
                    }
                }
            }
        }
    }

    public void RemoveContainer(Container container)
    {
        var slot = Slots.FirstOrDefault(s => s.ContainerId == container.Id);

        if (slot is null)
        {
            throw new WarehouseDomainException($"Cannot find container with id {container.ContainerId} in slice with id {Id}.");
        }

        slot.SetContainer(null);
    }

    public bool ContainContainer(Container container)
    {
        return Slots.Any(s => s.ContainerId == container.Id);
    }

    public void Rearrange()
    {
        // Vertical rearrangement
        for (uint columnId = 1; columnId <= NumberOfColumns; columnId++)
        {
            for (uint levelId = NumberOfLevels - 1; levelId > 0; levelId--)
            {
                var currentLevelId = levelId;
                var currentSlot = this.FindSlot(levelId, columnId);
                while (currentSlot.Container is null && currentLevelId < NumberOfLevels)
                {
                    var upperSlot = this.FindSlot(currentLevelId + 1, columnId); ;
                    if (upperSlot.Container is null)
                    {
                        break;
                    }

                    currentSlot.SetContainer(upperSlot.Container);
                    upperSlot.SetContainer(null);

                    currentSlot = upperSlot;
                    currentLevelId++;
                }
            }
        }

        // Horizontal rearrangement
        for (uint levelId = 1; levelId <= NumberOfLevels; levelId++)
        {
            for (uint columnId = NumberOfColumns - 1; columnId > 0; columnId--)
            {
                var currentColumnId = columnId;
                var currentSlot = this.FindSlot(levelId, columnId);
                while (currentSlot.Container is null && currentColumnId < NumberOfColumns)
                {
                    var outerSlot = this.FindSlot(levelId, currentColumnId + 1); ;
                    if (outerSlot.Container is null)
                    {
                        break;
                    }

                    currentSlot.SetContainer(outerSlot.Container);
                    outerSlot.SetContainer(null);

                    currentSlot = outerSlot;
                    currentColumnId++;

                }
            }
        }
    }

    public Slot FindSlot(uint levelId, uint columnId)
    {
        return Slots.First(s => s.LevelId == levelId && s.Id == columnId);
    }

    private bool IsLevelFull(uint levelId)
    {
        return !Slots.Any(s => s.LevelId == levelId && s.Container is null);
    }
}
