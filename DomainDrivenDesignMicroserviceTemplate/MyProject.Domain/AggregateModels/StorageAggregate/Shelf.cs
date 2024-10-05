using ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.StorageAggregate;

public class Shelf : Entity, IAggregateRoot
{
    public string ShelfId { get; private set; }
    public uint Priority { get; private set; }
    public List<Cell> Cells { get; private set; }

    public Shelf(string shelfId, uint priority)
    {
        ShelfId = shelfId;
        Cells = new List<Cell>();
        Priority = priority;
    }

    public void SetSize(uint height, uint width)
    {
        if (Cells.Any(
                c => c.Slices.Any(
                    s => s.Slots.Any(
                        sl => sl.Container is not null))))
        {
            throw new WarehouseDomainException($"The shelf with id {ShelfId} still contain container(s). Please clear the shelf before restructuring.");
        }

        for (uint rowId = 1; rowId <= height; rowId++)
        {
            for (uint cellId = 1; cellId <= width; cellId++)
            {
                var cell = new Cell(Id, rowId, cellId);
                Cells.Add(cell);
            }
        }
    }

    public void SetCellSize(uint rowId, uint cellId, uint width, uint height, uint depth)
    {
        var cell = Cells.FirstOrDefault(c => c.RowId == rowId && c.Id == cellId);
        if (cell is null)
        {
            throw new WarehouseDomainException($"Cell id {cellId} isn't valid.");
        }

        cell.SetSize(width, height, depth);
    }

    public void SetCellSliceItem(uint rowId, uint cellId, uint sliceId, Item item)
    {
        var cell = Cells.FirstOrDefault(c => c.RowId == rowId && c.Id == cellId);
        if (cell is null)
        {
            throw new WarehouseDomainException($"Cell id {cellId} isn't valid.");
        }

        var slice = cell.Slices.FirstOrDefault(s => s.Id == sliceId);
        if (slice is null)
        {
            throw new WarehouseDomainException($"Slice id {cellId} isn't valid.");
        }

        slice.SetItem(item);
    }

    public int GetRemainingSlot(Item item)
    {
        var cellSlices = Cells.SelectMany(c => c.Slices).ToList();
        if (cellSlices is null)
        {
            return 0;
        }

        return (int)cellSlices.Where(s => s.Item is not null && s.Item == item).Sum(s => s.FreeSlot);
    }

    public void AddContainers(IEnumerable<Container> containers)
    {
        var items = containers.Select(c => c.Item).Distinct();

        foreach (var item in items)
        {
            if (item is null)
            {
                throw new WarehouseDomainException("One of the containers contains null item.");
            }

            var itemContainers = containers.Where(c => c.Item is not null && c.Item == item).ToList();

            if (itemContainers.Count > GetRemainingSlot(item))
            {
                throw new WarehouseDomainException($"Insufficient space for item {item.ItemId}");
            }

            var numberOfRows = Cells.Max(c => c.RowId);


            for (int rowId = 1; rowId <= numberOfRows; rowId++)
            {
                var cellsWithItem = Cells
                    .Where(c => c.RowId == rowId && c.Slices.Any(s => s.Item is not null && s.Item == item))
                    .OrderBy(c => c.Id);

                foreach (var cell in cellsWithItem)
                {
                    var slices = cell.Slices.Where(s => s.Item is not null && s.Item == item);

                    foreach (var slice in slices)
                    {
                        if (slice.FreeSlot > itemContainers.Count)
                        {
                            slice.AddContainers(itemContainers);
                            itemContainers.RemoveAll(c => true);
                        }
                        else
                        {
                            int numberOfFreeSlots = (int)slice.FreeSlot;
                            var containersToAdd = itemContainers.Take(new Range(0, numberOfFreeSlots));

                            slice.AddContainers(containersToAdd);
                            itemContainers.RemoveRange(0, numberOfFreeSlots);
                        }

                        if (!itemContainers.Any())
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    public void RemoveContainers(IEnumerable<Container> containers)
    {
        List<Slice> changedSlices = new();
        foreach (var container in containers)
        {
            var sliceWithContainer = Cells
                .SelectMany(r => r.Slices)
                .FirstOrDefault(r => r.ContainContainer(container));

            if (sliceWithContainer is null)
            {
                throw new WarehouseDomainException($"The container with id {container.ContainerId} is not found in shelf {ShelfId}");
            }

            sliceWithContainer.RemoveContainer(container);
            changedSlices.Add(sliceWithContainer);
        }

        changedSlices.Distinct().ToList().ForEach(s => s.Rearrange());
    }
}
