using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models.Responses
{
    public class PeriodicTableResponseViewModel
    {
        public PeriodicTableResponseViewModel()
        {
            Groups = new List<GroupsViewModel>();
        }
        public int PeriodId { get; set; }
        public IList<GroupsViewModel> Groups { get; set; }
    }
}