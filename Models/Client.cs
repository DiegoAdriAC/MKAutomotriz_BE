using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class Client
    {
        public Client()
        {
            Cars = new HashSet<Car>();
            Reports = new HashSet<Report>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Mail { get; set; }
        public string? Rfc { get; set; }
        public string? Reason { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
