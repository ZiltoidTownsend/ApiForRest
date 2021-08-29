using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForRest.Models
{
    public class User : IdentityUser
    {
        public string HubConnectionId { get; set; }
        public string Role { get; set; }
    }
}
