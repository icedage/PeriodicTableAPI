using PeriodicTableAPI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models.Requests
{
    public class PeriodticTableSummaryResponseViewModel
    {
        public IList<PeriodDetailsResponseViewModel> Periods;
    }
}