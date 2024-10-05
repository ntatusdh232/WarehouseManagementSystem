namespace ChaWarehouseMicroservice.Domain.AggregateModels.StorageAggregate;

public class Cell
{
    public int ShelfId { get; private set; }
    public uint RowId { get; private set; }
    public uint Id { get; private set; }
    public List<Slice> Slices { get; private set; }

    public Cell(int shelfId, uint rowId, uint id)
    {
        ShelfId = shelfId;
        RowId = rowId;
        Id = id;
        Slices = new List<Slice>();
    }

    public void SetSize(uint width, uint height, uint depth)
    {

        if (Slices is not null)
        {
            if (Slices.Any(s => s.Slots.Any(sl => sl.Container is not null)))
            {
                throw new WarehouseDomainException($"The cell with id {Id} still contain container(s). Please clear the cell before restructuring.");
            }
        }

        Slices = new List<Slice>();
        for (uint sliceId = 1; sliceId <= width; sliceId++)
        {
            var slice = new Slice(ShelfId, RowId, Id, sliceId);
            Slices.Add(slice);
            for (uint levelId = 1; levelId <= height; levelId++)
            {
                for (uint columnId = 1; columnId <= depth; columnId++)
                {
                    var slot = new Slot(ShelfId, RowId, Id, sliceId, levelId, columnId);
                    slice.Slots.Add(slot);
                }
            }
        }
    }
}
