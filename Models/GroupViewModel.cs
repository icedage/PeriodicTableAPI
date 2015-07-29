using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Models
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public ElementViewModel Element { get; set; }
    }
}