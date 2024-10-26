

namespace WMS.Api.Application.Commands.Items
{
    public class CreateItemsCommand : IRequest<bool>
    {
        public List<CreateItemViewModel> Items { get; set; }
    }
}
