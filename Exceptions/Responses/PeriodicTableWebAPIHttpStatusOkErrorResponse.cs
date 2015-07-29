using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PeriodicTableAPI.Exceptions.Responses
{
    [DataContract]
    public class PeriodicTableWebAPIHttpStatusOkErrorResponse
    {
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}