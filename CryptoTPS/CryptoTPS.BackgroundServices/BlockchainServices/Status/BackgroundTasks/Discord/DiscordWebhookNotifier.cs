﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices.Status.BackgroundTasks.Discord
{
    public class DiscordWebhookNotifier
    {
        private readonly HttpClient _httpClient;

        public DiscordWebhookNotifier(string baseUrl)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl, UriKind.Absolute)
            };
        }

        public async Task<HttpResponseMessage> SendNotificationAsync(WebhookMessage message) => await _httpClient.PostAsync(string.Empty, JsonContent.Create(message));
    }
}
