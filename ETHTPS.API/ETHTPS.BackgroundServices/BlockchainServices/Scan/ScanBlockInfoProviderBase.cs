﻿using ETHTPS.Data.Extensions.StringExtensions;
using ETHTPS.Services.BlockchainServices.Scan.Extensions;

using Fizzler.Systems.HtmlAgilityPack;

using HtmlAgilityPack;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETHTPS.Services.BlockchainServices.Scan
{
    public abstract class ScanBlockInfoProviderBase : IBlockInfoProvider
    {
        protected readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _blockInfoEndpointBase;
        private readonly ScanRequestModelFactory _requestModelFactory;
        private readonly string _txCountSelector;
        private readonly string _gasUsedSelector;
        private readonly string _dateSelector;

        protected ScanBlockInfoProviderBase(IConfiguration configuration, string providerName)
        {
            var config = configuration.GetSection("BlockInfoProviders").GetSection(providerName);
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(config.GetValue<string>("Endpoint"))
            };
            _apiKey = config.GetValue<string>("APIKey");
            _requestModelFactory = new ScanRequestModelFactory(_apiKey);
            _blockInfoEndpointBase = config.GetValue<string>("BlockInfoEndpointBase");
            _txCountSelector = config.GetValue<string>("TXCountSelector");
            _gasUsedSelector = config.GetValue<string>("GasUsedSelector");
            _dateSelector = config.GetValue<string>("DateSelector");
        }

        public Task<BlockInfo> GetBlockInfoAsync(int blockNumber)
        {

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(_blockInfoEndpointBase + blockNumber);

            var txCountNode = doc.DocumentNode.QuerySelectorAll(_txCountSelector);
            var txCount = new string(txCountNode.First().InnerText.RemoveAllNonNumericCharacters());

            var gasUsedNode = doc.DocumentNode.QuerySelectorAll(_gasUsedSelector);
            var gasUsed = new string(gasUsedNode.First().InnerText.UntilParanthesis().RemoveAllNonNumericCharacters());

            var dateNode = doc.DocumentNode.QuerySelectorAll(_dateSelector);
            var dateString = dateNode.First().InnerText.BetweenParantheses().Replace(" +UTC", "");
            DateTime date;
            //(Sep-17-2021 06:40:08 AM +UTC) 
            if (DateTime.TryParseExact(dateString, "MMM-dd-yyyy hh:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out date))
            {

            }

            return Task.FromResult(new BlockInfo()
            {
                BlockNumber = blockNumber,
                GasUsed = double.Parse(gasUsed),
                TransactionCount = int.Parse(txCount),
                Date = date
            });
        }

        public async Task<BlockInfo> GetBlockInfoAsync(DateTime time)
        {
            var blockNumberRequest = await _httpClient.GetAsync(_requestModelFactory.CreateGetBlockNumberByTimestampRequest(time).ToQueryString());
            string blockNumber = JsonConvert.DeserializeObject<dynamic>(await blockNumberRequest.Content.ReadAsStringAsync()).result.ToString();
            return await GetBlockInfoAsync(int.Parse(blockNumber));
        }

        public async Task<BlockInfo> GetLatestBlockInfoAsync() => await GetBlockInfoAsync(DateTime.Now);

        private async Task GetBlockNumberByTimestamp()
        {

        }
    }
}