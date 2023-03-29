﻿using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class UpdateExpenseCommandRequest : IRequest
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
