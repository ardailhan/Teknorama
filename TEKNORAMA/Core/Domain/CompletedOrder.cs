﻿namespace TeknoramaBackOffice.Core.Domain
{
    public class CompletedOrder : BaseEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
