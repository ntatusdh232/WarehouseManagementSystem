namespace WMS.Api.Application.Commands.Departments
{
    [DataContract]
    public class CreateDepartmentCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public CreateDepartmentCommand(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
