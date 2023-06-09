﻿using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries.TerritoryQueries
{
    public class GetTerritoryQueryRequest : IRequest<TerritoryListDto>
    {
        public int Id { get; set; }

        public GetTerritoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
