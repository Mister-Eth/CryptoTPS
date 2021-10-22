﻿using ETHTPS.Data.Database;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETHTPS.BackgroundServices.TPSDataUpdaters.Standard
{
    public class DummyDyDxUpdater : TPSDataUpdaterBase
    {
        private static readonly Random _random = new Random();
        public DummyDyDxUpdater(IServiceScopeFactory scopeFactory, ILogger<BackgroundServiceBase> logger) : base("DyDx", scopeFactory, logger, TimeSpan.FromSeconds(5))
        {

        }

        public override async Task<TPSData> LogDataAsync(ETHTPSContext context)
        {
            var value = _random.Next(100);
            //Random values inspired by https://pbs.twimg.com/media/FAZmFInUcAUBJ4d?format=png&name=small
            //Until data is publicly available
            double tps = 0;
            if (value < 2)
            {
                tps = _random.Next(25, 30);
            }
            else if (value < 5)
            {
                tps = _random.Next(20, 25);
            }
            else if (value < 8)
            {
                tps = _random.Next(15, 20);
            }
            else if (value < 11)
            {
                tps = _random.Next(10, 15);
            }
            else if (value < 80)
            {
                tps = _random.Next(3, 5);
            }
            else
            {
                tps = _random.Next(0, 2);
            }
            var provider = context.Providers.First(x => x.Name == Name);
            var data = new TPSData()
            {
                Date = DateTime.Now,
                Provider = provider.Id,
                Tps = tps //block time
            };
            context.Tpsdata.Add(data);
            await context.SaveChangesAsync();
            _logger.LogInformation($"{Name}: {data.Tps}TPS");
            return data;
        }
    }
}
