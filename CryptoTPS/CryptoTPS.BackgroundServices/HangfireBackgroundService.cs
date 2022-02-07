using CryptoTPS.Data.Database;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services
{
    public abstract class HangfireBackgroundService
    {
        protected readonly ILogger<HangfireBackgroundService> _logger;
        protected readonly CryptoTPSContext _context;

        protected HangfireBackgroundService(ILogger<HangfireBackgroundService> logger, CryptoTPSContext context)
        {
            _logger = logger;
            _context = context;
        }

        public abstract Task RunAsync();
    }
}
