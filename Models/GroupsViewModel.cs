using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models
{
    public class GroupsViewModel
    {
        public int GroupId { get; set; }
        public IList<ElementViewModel> Elements { get; set; }
    }
}