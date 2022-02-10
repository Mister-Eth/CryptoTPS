using CryptoTPS.Data.Database;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services
{
    public abstract class HangfireBackgroundServiceWithHttpClient : HangfireBackgroundService
    {
        protected readonly HttpClient _httpClient;

        protected HangfireBackgroundServiceWithHttpClient(ILogger<HangfireBackgroundService> logger, CryptoTPSContext context) : base(logger, context)
        {
            _httpClient = new HttpClient();
        }
    }
}
