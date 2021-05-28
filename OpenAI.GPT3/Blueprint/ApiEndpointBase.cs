using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI.GPT3.Blueprint
{   public abstract class ApiEndpointBase
    {
        protected readonly Api _api;

        protected ApiEndpointBase(Api api)
        {
            _api = api;
        }
    }
}
