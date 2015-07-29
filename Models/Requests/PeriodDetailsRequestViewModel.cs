using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models.Requests
{
    public class PeriodDetailsRequestViewModel
    {
        public int PeriodId { get; set; }
        public int GroupId  { get; set; }
    }
}