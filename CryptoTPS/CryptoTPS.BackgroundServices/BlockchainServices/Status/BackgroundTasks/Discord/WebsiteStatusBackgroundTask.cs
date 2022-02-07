using CryptoTPS.Data.Database;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices.Status.BackgroundTasks.Discord
{
    public class WebsiteStatusBackgroundTask : URLMonitoringBackgroundTask
    {
        public WebsiteStatusBackgroundTask(ILogger<HangfireBackgroundService> logger, CryptoTPSContext context, IConfiguration configuration) : base(logger, context, configuration, "https://CryptoTPS.info")
        {
        }
    }
}
