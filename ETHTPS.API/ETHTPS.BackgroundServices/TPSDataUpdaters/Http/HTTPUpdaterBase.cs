﻿using ETHTPS.Services.TPSDataUpdaters;
using ETHTPS.Data.Database;

using Fizzler.Systems.HtmlAgilityPack;

using HtmlAgilityPack;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ETHTPS.Services.TPSDataUpdaters.Http
{
    public abstract class HTTPUpdaterBase : TPSDataUpdaterBase
    {
        public string BaseURL { get; private set; }
        private readonly string _targetElementSelector;
        private readonly HttpClient _httpClient;

        protected HTTPUpdaterBase(string name, ETHTPSContext context, ILogger<HangfireBackgroundService> logger, IConfiguration configuration) : base(name, logger, context)
        {
            var config = configuration.GetSection("TPSLoggerConfigurations").GetSection("HTTPTPSLoggerConfiguration").GetSection(name);
            BaseURL = config.GetValue<string>("BaseURL");
            _targetElementSelector = config.GetValue<string>("TargetElement"); 
            _httpClient = new HttpClient();
        }

        public override Task<Tpsdatum> GetDataAsync()
        {
            var data = default(Tpsdatum);
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(BaseURL);

                var nodes = doc.DocumentNode.QuerySelectorAll(_targetElementSelector);
                var x = new string(nodes.First().InnerText.Where(c => char.IsNumber(c) || c == '.').ToArray());
                var provider = _context.Providers.First(x => x.Name == Name);
                data = new Tpsdatum()
                {
                    Date = DateTime.Now,
                    Provider = provider.Id,
                    Tps = float.Parse(x)
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"{Name}: {e.Message}");
            }
            return Task.FromResult(data);
        }
    }
}
