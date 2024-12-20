﻿namespace WMS.Api.Application.Queries.FinishedProductIssues
{
    public class GetProductIssueByIdQueryHandler : IRequestHandler<GetProductIssueByIdQuery, FinishedProductIssueViewModel>
    {
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;
        private readonly IMapper _mapper;

        public GetProductIssueByIdQueryHandler(IFinishedProductIssueRepository finishedProductIssueRepository, IMapper mapper)
        {
            _finishedProductIssueRepository = finishedProductIssueRepository;
            _mapper = mapper;
        }

        public async Task<FinishedProductIssueViewModel> Handle(GetProductIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var productIssue = await _finishedProductIssueRepository.GetIssueById(request.ProductIssueId);

            if (productIssue is null)
            {
                throw new EntityNotFoundException(nameof(FinishedProductIssue), request.ProductIssueId);
            }

            var productIssueViewModel = _mapper.Map<FinishedProductIssueViewModel>(productIssue);

            return productIssueViewModel;

        }
    }
}


