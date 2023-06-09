﻿using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketItemCommands
{
    public class UpdateBasketItemCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
