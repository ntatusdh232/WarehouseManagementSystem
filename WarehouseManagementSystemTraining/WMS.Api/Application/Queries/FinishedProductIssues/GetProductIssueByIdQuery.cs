﻿namespace WMS.Api.Application.Queries.FinishedProductIssues
{
    public class GetProductIssueByIdQuery : PaginatedQuery, IRequest<FinishedProductIssueViewModel>
    {
        public string ProductIssueId { get; set; }
        public GetProductIssueByIdQuery(string productIssueId)
        {
            ProductIssueId = productIssueId;
        }
    }
}


