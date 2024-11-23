namespace WMS.Api.Application.Queries.Departments
{
    public class DepartmentViewModel
    {
        public string DepartmentId { get; set; }
        public string Name { get; set; }

#pragma warning disable CS8618
        private DepartmentViewModel() { }

        public DepartmentViewModel(string departmentId, string name)
        {
            DepartmentId = departmentId;
            Name = name;
        }
#pragma warning restore CS8618


    }
}
