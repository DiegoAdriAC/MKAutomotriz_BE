using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class Report
    {
        public Report()
        {
            ListProves = new HashSet<ListProve>();
            ListServices = new HashSet<ListService>();
        }

        public int IdReport { get; set; }
        public int NoOrden { get; set; }
        public int? Bill { get; set; }
        public DateTime? StarDate { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public int Mileage { get; set; }
        public int PayId { get; set; }
        public DateTime? PayDate { get; set; }
        public decimal Total { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
        public virtual Pay Pay { get; set; } = null!;
        public virtual ICollection<ListProve> ListProves { get; set; }
        public virtual ICollection<ListService> ListServices { get; set; }
    }
}
