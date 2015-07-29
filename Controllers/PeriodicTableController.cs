using PeriodicTableAPI.Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeriodicTableAPI.Controllers
{
    public class PeriodicTableController : ApiController
    {
         //
        // GET: /PeriodDetails/
        private readonly IPeriodicDetailsPresenter _periodDetailsPresenter;
        
        public PeriodicTableController(IPeriodicDetailsPresenter periodDetailsPresenter)
        {
            _periodDetailsPresenter = periodDetailsPresenter;
        }

        public HttpResponseMessage Get()
        {
           var response = _periodDetailsPresenter.GetPeriodicTable();
            HttpResponseMessage httpResponse=null;
            httpResponse = Request.CreateResponse(HttpStatusCode.OK, response);
            return httpResponse;
         }
    }
}
