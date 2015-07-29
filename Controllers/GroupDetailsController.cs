using PeriodicTableAPI.Exceptions.Responses;
using PeriodicTableAPI.Models.Requests;
using PeriodicTableAPI.Presenters.Interfaces;
using PeriodicTableAPI.Services.Helpers;
using PeriodicTableAPI.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeriodicTableAPI.Controllers
{
    public class GroupDetailsController : ApiController
    {
        private readonly IPeriodicDetailsPresenter _periodDetailsPresenter;

        public GroupDetailsController(IPeriodicDetailsPresenter periodDetailsPresenter)
        {
            _periodDetailsPresenter = periodDetailsPresenter;
        }

        public HttpResponseMessage Get(int id)
        {
            var periodDetialsRequestViewModel = new PeriodDetailsRequestViewModel() { PeriodId = id };
            var serviceResponse = _periodDetailsPresenter.GetListingsByGroupId(periodDetialsRequestViewModel);
            HttpResponseMessage httpResponse;

            switch (serviceResponse.StatusCode)
            {
                case PeriodicTableStatusCodes.Success:
                    httpResponse = Request.CreateResponse(HttpStatusCode.OK, serviceResponse);
                    break;
                case PeriodicTableStatusCodes.Error:
                    var internalServiceError = PeriodicTableServerExceptionResponse.GetInternalServiceError();
                    httpResponse = Request.CreateResponse(HttpStatusCode.InternalServerError, internalServiceError);
                    break;
                default:
                    var error = new HttpError(GetCorrectErrorMessage(serviceResponse.StatusCode))
                                    {
                                        {"ErrorCode", serviceResponse.StatusCode}
                                    };
                    httpResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
                    break;
            }
            return httpResponse;
        }

        private string GetCorrectErrorMessage(PeriodicTableStatusCodes status)
        {
            switch (status)
            {
                case PeriodicTableStatusCodes.InvalidPeriodId:
                    return Constants.ValidationErrorSecurePeriodIdIsRequired;
                case PeriodicTableStatusCodes.InvalidGroupId:
                    return Constants.ValidationErrorGroupIdIsRequired;
                default:
                    return string.Empty;
            }
        }
    }
}
