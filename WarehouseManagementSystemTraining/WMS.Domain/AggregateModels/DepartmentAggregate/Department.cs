namespace WMS.Domain.AggregateModels.DepartmentAggregate
{
    public class Department : IAggregateRoot
    {
        public string Name { get; private set; }

        public Department(string name)
        {
            Name = name;
        }

    }
}
