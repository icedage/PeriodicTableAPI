using PeriodicTableAPI.Models.Requests;
using PeriodicTableAPI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableAPI.Presenters.Interfaces
{
    public interface IPeriodicDetailsPresenter
    {
        PeriodDetailsResponseViewModel GetPeriodicDetailsByPeriodId(PeriodDetailsRequestViewModel periodDetailsRequestViewModel);
        GroupDetailsResponseViewModel GetListingsByGroupId(PeriodDetailsRequestViewModel periodDetailsRequestViewModel);
        IList<PeriodicTableResponseViewModel> GetPeriodicTable();
    }
}
