using System;
using System.Collections.Generic;

namespace StockControl.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Surname { get; set; }
        public string? FirstName { get; set; }
        public string? UserType { get; set; }
        public bool? Active { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
