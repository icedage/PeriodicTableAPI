using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models
{
    public class PeriodViewModel 
    {
        public PeriodViewModel()
        {
            Element = new ElementViewModel();
        }
        public int PeriodId { get; set; }
        public ElementViewModel Element { get; set; }
    }
}