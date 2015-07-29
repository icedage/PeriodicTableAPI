﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PeriodicTableAPI.Exceptions.Responses
{
    public interface IPeriodicTableServerExceptionResponse
    {
        HttpResponseException GetException(HttpRequestMessage message);     
    }
}
