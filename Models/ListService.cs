using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class ListService
    {
        public int IdListSerive { get; set; }
        public int ReportId { get; set; }
        public int ServiceId { get; set; }

        public virtual Report Report { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
