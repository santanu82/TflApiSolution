﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TflRestApi.Logic
{
    public class ApiErrorResponse
    {
        [JsonProperty("$type")]
        public string ApiType { get; set; }

        [JsonProperty("timestampUtc")]
        public string TimestampUtc { get; set; }

        [JsonProperty("exceptionType")]
        public string ExceptionType { get; set; }

        [JsonProperty("httpStatusCode")]
        public int HttpStatusCode { get; set; }

        [JsonProperty("httpStatus")]
        public string HttpStatus { get; set; }

        [JsonProperty("relativeUri")]
        public string RelativeUri { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
