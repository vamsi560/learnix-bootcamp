using System;
using System.Collections.Generic;

#nullable disable

namespace AzureBootCamp.Context
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string Tracks { get; set; }
        public string Experience { get; set; }
    }
}
