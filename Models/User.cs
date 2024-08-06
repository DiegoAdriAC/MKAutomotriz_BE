using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
