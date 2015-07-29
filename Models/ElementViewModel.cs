using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models
{
    public class ElementViewModel
    {
        public int ElementId { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Color { get; set; }
        public decimal AtomicWeigh { get; set; }
        public string State { get; set; }
        public string MeltingPoint { get; set; }
        public string Boilingpoint { get; set; }
        public int Electrons { get; set; }
        public int Protons { get; set; }
        public int Neutrons { get; set; }
        public string ElectronShells { get; set; }
        public int ElectronConfiguration { get; set; }
        public string Density { get; set; }
    }
}

