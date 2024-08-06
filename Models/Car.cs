using System;
using System.Collections.Generic;

namespace MKAutomotriz_BE.Models
{
    public partial class Car
    {
        public Car()
        {
            Reports = new HashSet<Report>();
        }

        public int IdCar { get; set; }
        public string? NoUnit { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string Color { get; set; } = null!;
        public string Plates { get; set; } = null!;
        public int ClientId { get; set; }

        public virtual Client? Client { get; set; } = null!;
        public virtual ICollection<Report> Reports { get; set; }
    }
}
