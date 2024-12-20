﻿namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetGoodsIssueByIdQuery : PaginatedQuery, IRequest<GoodsIssueViewModel>
    {
        public string GoodsIssueId { get; set; }
        public GetGoodsIssueByIdQuery(string goodsIssueId)
        {
            GoodsIssueId = goodsIssueId;
        }
    }
}


