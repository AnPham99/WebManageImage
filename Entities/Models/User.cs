using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsLike { set; get; }
        public List<Image> Images { set; get; }
        public Like Like { set; get; }
    }

}
