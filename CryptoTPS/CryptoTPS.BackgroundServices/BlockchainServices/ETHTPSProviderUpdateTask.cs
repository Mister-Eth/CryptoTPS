using CryptoTPS.Data.Database;
using CryptoTPS.Services.BlockchainServices.Status.BackgroundTasks.Discord;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices
{
    public class ETHTPSProviderUpdateTask : HangfireBackgroundServiceWithHttpClient
    {

        private readonly DiscordWebhookNotifier _discordWebhookNotifier;
        public ETHTPSProviderUpdateTask(ILogger<HangfireBackgroundService> logger, CryptoTPSContext context, IConfiguration configuration) : base(logger, context)
        {
            _discordWebhookNotifier = new DiscordWebhookNotifier(configuration.GetSection("Discord").GetValue<string>("WebhookURL"));
        }

        public override async Task RunAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.ethtps.info/API/v2/Providers");
            var result = JsonConvert.DeserializeObject<Provider[]>(response);
            var providers = result.Where(x => x.type != "Mainnet");
            var ethID = _context.Providers.First(x => x.Name == "Ethereum").Id;
            foreach (var provider in providers)
            {
                if (!_context.Providers.Any(x => x.Name == provider.name))
                {
                    var entry = new Data.Database.Provider()
                    {
                        Color = provider.color,
                        Name = provider.name,
                        Enabled = true
                    };
                    if (provider.type != "Sidechain")
                    {
                        entry.SubchainOf = ethID;
                    }
                    _context.Providers.Add(entry);
                    _context.SaveChanges();
                    await _discordWebhookNotifier.SendNotificationAsync(new WebhookMessage()
                    {
                        content = "New Ethereum project added",
                        embeds =new Embed[]
                        {
                            new Embed()
                            {
                                title = provider.name
                            }
                        }
                    });
                }
            }
        }

        public class ResponseModel
        {
            public Provider[] Property1 { get; set; }
        }

        public class Provider
        {
            public string name { get; set; }
            public string color { get; set; }
            public int theoreticalMaxTPS { get; set; }
            public string type { get; set; }
            public bool isGeneralPurpose { get; set; }
        }

    }
}
