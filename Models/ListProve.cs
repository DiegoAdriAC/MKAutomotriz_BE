using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class ListProve
    {
        public int IdListProve { get; set; }
        public int ReportId { get; set; }
        public int ProveId { get; set; }
        public int Bill { get; set; }
        public int PayId { get; set; }
        public decimal SubTotal { get; set; }
        public bool Status { get; set; }

        public virtual Pay Pay { get; set; } = null!;
        public virtual Prove Prove { get; set; } = null!;
        public virtual Report Report { get; set; } = null!;
    }
}
