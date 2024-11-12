
namespace WMS.Api.Application.Queries.FinishedProductIssues
{
    public class GetAllReceiversQueryHandler : IRequestHandler<GetAllReceiversQuery, IEnumerable<string>>
    {
        private readonly IMapper _mapper;
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;

        public GetAllReceiversQueryHandler(IMapper mapper, IFinishedProductIssueRepository finishedProductIssueRepository)
        {
            _mapper = mapper;
            _finishedProductIssueRepository = finishedProductIssueRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetAllReceiversQuery request, CancellationToken cancellationToken)
        {
            var receivers = await _finishedProductIssueRepository.GetReceivers();

            return receivers;
        }
    }
}


