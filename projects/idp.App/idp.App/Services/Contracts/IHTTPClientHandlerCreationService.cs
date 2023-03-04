using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace idp.App.Services.Contracts
{
    public interface IHTTPClientHandlerCreationService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
