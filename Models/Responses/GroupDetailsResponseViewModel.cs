using PeriodicTableAPI.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models.Responses
{
    public class GroupDetailsResponseViewModel
    {
        public GroupDetailsResponseViewModel()
        {
            Periods = new List<PeriodViewModel>();
        }

        public int GroupId { get; set; }
        public IList<PeriodViewModel> Periods { get; set; }
        public PeriodicTableStatusCodes StatusCode { get; set; }
    }
}