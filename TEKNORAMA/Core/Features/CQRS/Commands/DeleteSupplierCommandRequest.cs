﻿using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteSupplierCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteSupplierCommandRequest(int id)
        {
            Id = id;
        }
    }
}
