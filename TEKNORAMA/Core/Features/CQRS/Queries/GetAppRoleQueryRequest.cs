﻿using MediatR;
using TeknoramaBackOffice.Core.DTOs;

namespace TeknoramaBackOffice.Core.Features.CQRS.Queries
{
    public class GetAppRoleQueryRequest : IRequest<AppRoleListDto>
    {
        public int Id { get; set; }

        public GetAppRoleQueryRequest(int id)
        {
            Id = id;
        }
    }
}
