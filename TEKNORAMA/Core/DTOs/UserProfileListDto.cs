﻿using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.DTOs
{
    public class UserProfileListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TCNO { get; set; }
        public short? Age { get; set; }
        public string ImagePath { get; set; }
        public Gender? Gender { get; set; }
        public int AppUserId { get; set; }
    }
}