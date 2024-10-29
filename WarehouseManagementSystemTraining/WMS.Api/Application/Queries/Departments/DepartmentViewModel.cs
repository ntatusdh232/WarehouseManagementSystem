namespace WMS.Api.Application.Queries.Departments
{
    public class DepartmentViewModel
    {
        public string Name { get; set; }

#pragma warning disable CS8618
        private DepartmentViewModel() { }
#pragma warning restore CS8618 

        public DepartmentViewModel(string name)
        {
            Name = name;
        }
    }
}
