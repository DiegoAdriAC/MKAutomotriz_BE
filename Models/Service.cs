using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class Service
    {
        public Service()
        {
            ListServices = new HashSet<ListService>();
        }

        public int IdService { get; set; }
        public string Desc { get; set; } = null!;
        public decimal? Price { get; set; }

        public virtual ICollection<ListService> ListServices { get; set; }
    }
}
