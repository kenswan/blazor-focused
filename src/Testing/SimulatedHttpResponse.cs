﻿using System.Net;

namespace BlazorFocused.Testing
{
    internal class SimulatedHttpResponse : SimulatedHttpRequest
    {
        public HttpStatusCode StatusCode { get; set; }

        public object Response { get; set; }
    }
}
