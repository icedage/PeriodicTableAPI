using PeriodicTableAPI.StatusCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PeriodicTableAPI.Exceptions.Responses
{
    public class PeriodicTableServerExceptionResponse : IPeriodicTableServerExceptionResponse
    {
        public HttpResponseException GetException(HttpRequestMessage message)
        {
            var httpError = GetInternalServiceError();
            return new HttpResponseException(message.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError));
        }

        public static HttpError GetInternalServiceError()
        {
            var internalServiceError = new HttpError("Sorry, an error occurred while processing your request.")
                                {
                                    {"ErrorCode", (int) PeriodicTableStatusCodes.Error}
                                };

            return internalServiceError;
        }
    }
}