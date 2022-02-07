using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices.Status.BackgroundTasks.Discord
{
    public class WebhookMessage
    {
        public string content { get; set; }
        public Embed[] embeds { get; set; }
    }
}
