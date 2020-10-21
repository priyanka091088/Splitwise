using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public float Balance { get; set; }
    }
}
