namespace WMS.Domain.AggregateModels.EmployeeAggregate
{
    public class Employee : IAggregateRoot
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }



#pragma warning disable CS8618
        private Employee() { }
        public Employee(string employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }

        public Employee(string employeeId)
        {
            EmployeeId = employeeId;
        }

        public void Update(string employeeName)
        {
            EmployeeName = employeeName;
        }




    }

}
