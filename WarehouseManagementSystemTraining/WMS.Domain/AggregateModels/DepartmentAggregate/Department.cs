namespace WMS.Domain.AggregateModels.DepartmentAggregate
{
    public class Department : IAggregateRoot
    {
        [Key]
        public string DepartmentId { get; private set; }

        [Required]
        public string Name { get; private set; }

        public Department(string departmentId, string name)
        {
            DepartmentId = departmentId;
            Name = name;
        }
    }
}
