using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class Prove
    {
        public Prove()
        {
            ListProves = new HashSet<ListProve>();
        }

        public int IdProve { get; set; }
        public int? NoProve { get; set; }
        public string? Desc { get; set; }

        public virtual ICollection<ListProve> ListProves { get; set; }
    }
}
