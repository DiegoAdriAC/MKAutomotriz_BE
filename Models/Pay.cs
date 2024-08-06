using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class Pay
    {
        public Pay()
        {
            ListProves = new HashSet<ListProve>();
            Reports = new HashSet<Report>();
        }

        public int IdPay { get; set; }
        public string Desc { get; set; } = null!;

        public virtual ICollection<ListProve> ListProves { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
