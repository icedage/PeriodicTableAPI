using PeriodicTableAPI.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models.Responses
{
    public class PeriodDetailsResponseViewModel
    {
        public PeriodDetailsResponseViewModel()
        {
            Groups = new List<GroupViewModel>();
        }

        public int PeriodId { get; set; }
        public IList<GroupViewModel> Groups { get; set; }
        public PeriodicTableStatusCodes StatusCode { get; set; }
    }
}