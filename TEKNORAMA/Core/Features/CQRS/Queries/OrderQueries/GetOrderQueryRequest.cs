﻿using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.OrderQueries
{
    public class GetOrderQueryRequest : IRequest<OrderListDto>
    {
        public int Id { get; set; }

        public GetOrderQueryRequest(int id)
        {
            Id = id;
        }
    }
}
