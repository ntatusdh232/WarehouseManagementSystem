using ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.StorageAggregate;

public class Slot
{
    public int ShelfId { get; private set; }
    public uint RowId { get; private set; }
    public uint CellId { get; private set; }
    public uint SliceId { get; private set; }
    public uint LevelId { get; private set; }
    public uint Id { get; private set; }
    public int? ContainerId { get; private set; }
    public Container? Container { get; private set; }

    public Slot(int shelfId, uint rowId, uint cellId, uint sliceId, uint levelId, uint id)
    {
        ShelfId = shelfId;
        RowId = rowId;
        CellId = cellId;
        SliceId = sliceId;
        LevelId = levelId;
        Id = id;
    }

    public void SetContainer(Container? container)
    {
        Container = container;
    }
}
