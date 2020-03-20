using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WeVsVirus.Models
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public DateTimeOffset Birthday { get; set; }

        [NotMapped]
        public ICollection<string> Roles { get; set; } = new List<string>();
    }
}
