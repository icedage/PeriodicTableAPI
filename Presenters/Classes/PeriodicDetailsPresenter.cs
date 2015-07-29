using PeriodicTableAPI.Models;
using PeriodicTableAPI.Models.Requests;
using PeriodicTableAPI.Models.Responses;
using PeriodicTableAPI.Presenters.Interfaces;
using PeriodicTableAPI.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeriodicTableAPI.Presenters.Classes
{
    public class PeriodicDetailsPresenter : IPeriodicDetailsPresenter
    {
        private readonly IPeriodicTableService _service;
        public PeriodicDetailsPresenter(IPeriodicTableService service)
        {
            _service = service;
        }
        public PeriodDetailsResponseViewModel GetPeriodicDetailsByPeriodId(PeriodDetailsRequestViewModel periodDetailsRequestViewModel)
        {
            var listings = _service.GetListingsByPeriodId(periodDetailsRequestViewModel.PeriodId);
            var response = new PeriodDetailsResponseViewModel();

            listings.Elements.ForEach(x => response.Groups.Add(
                                                                new GroupViewModel()
                                                                                        {
                                                                                            GroupId = x.GroupId,
                                                                                            Element = new ElementViewModel() {
                                                                                                                                ElementId = x.ElementId,
                                                                                                                                Name = x.Name,
                                                                                                                                AtomicWeigh = x.AtomicWeigh,
                                                                                                                                Classification = x.Classification,
                                                                                                                                Color = x.Color,
                                                                                                                                Density = x.Density,
                                                                                                                                ElectronConfiguration = x.ElectronConfiguration,
                                                                                                                                Electrons = x.Electrons,
                                                                                                                                ElectronShells = x.ElectronShells,
                                                                                                                                Neutrons = x.Neutrons,
                                                                                                                                Protons = x.Protons,
                                                                                                                                State = x.State,
                                                                                                                                MeltingPoint = x.MeltingPoint
                                                                                                                            }
                                                                                          }
                                                                ));
            return response;
        }

        public GroupDetailsResponseViewModel GetListingsByGroupId(PeriodDetailsRequestViewModel periodDetailsRequestViewModel)
        {
            var listings = _service.GetListingsByGroupId(periodDetailsRequestViewModel.PeriodId);
            var response = new GroupDetailsResponseViewModel();
             listings.Lists.ToList().ForEach(
                                                x => response.Periods.Add(new PeriodViewModel() { 
                                                                                                    PeriodId = x.PeriodId, 
                                                                                                    Element = new ElementViewModel { 
                                                                                                                                        ElementId=x.Element.ElementId,
                                                                                                                                        AtomicWeigh=x.Element.AtomicWeigh,
                                                                                                                                        Classification=x.Element.Classification,
                                                                                                                                        Color =  x.Element.Color,
                                                                                                                                        Density =  x.Element.Density,
                                                                                                                                        ElectronConfiguration =  x.Element.ElectronConfiguration,
                                                                                                                                        Electrons =  x.Element.Electrons,
                                                                                                                                        ElectronShells = x.Element.ElectronShells,
                                                                                                                                        Name = x.Element.Name,
                                                                                                                                        Neutrons = x.Element.Neutrons,
                                                                                                                                        Protons = x.Element.Protons,
                                                                                                                                        State = x.Element.State
                                                                                                                                    } 
                                                                                                }
                                                                                            ));

            response.GroupId = listings.GroupId;
            return response;
        }

        public IList<PeriodicTableResponseViewModel> GetPeriodicTable()
        {
            var elementListings = _service.GetPeriodicTable();
            var listings = new List<PeriodicTableResponseViewModel>();
            listings.ToList().ForEach(x =>

             listings.Add(new PeriodicTableResponseViewModel()
             {
                 PeriodId = x.PeriodId,
                 Groups = x.Groups.Select(i => new GroupsViewModel()
                 {
                     GroupId = i.GroupId,

                     Elements = i.Elements.Select(k => new ElementViewModel() { AtomicWeigh = k.AtomicWeigh }).ToList()
                 }).ToList()
             }
            ));
            return listings;
        }
    }
}