using CryptoTPS.Data.Database;
using CryptoTPS.Data.Database.TimeWarp;
using CryptoTPS.Data.Database.TimeWarp.Models;
using CryptoTPS.Data.Extensions;
using CryptoTPS.Data.ResponseModels;
using CryptoTPS.Services;
using CryptoTPS.Services.BlockchainServices.Extensions;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTPS.API.Infrastructure.Services.Implementations
{
    public class TimeWarpService : ITimeWarpService
    {
        private readonly CryptoTPSContext _context;
        private readonly IServiceProvider _services;

        public TimeWarpService(CryptoTPSContext context, IServiceProvider services)
        {
            _context = context;
            _services = services;
        }

        public DateTime GetEarliestDate()
        {
            var oldest = _context.TimeWarpData.OrderByDescending(x => x.StartDate).FirstOrDefault();
            if (oldest != null)
            {
                return oldest.StartDate;
            }
            else return DateTime.MinValue;
        }

        public async Task<TimeWarpSyncProgressModel> GetSyncProgress(string provider, string network)
        {
            var blockInfoProvider = _services.GetProvider(provider);
            var earliestSyncedBlockHeight = 0;
            if (_context.TimeWarpData.Any(x => x.ProviderNavigation.Name == provider))
            {
                var entry = _context.TimeWarpData.Where(x => x.ProviderNavigation.Name == provider).OrderByDescending(x => x.Block).First().Block;
                if (entry.HasValue)
                {
                    earliestSyncedBlockHeight = entry.Value;
                }
            }
            return new TimeWarpSyncProgressModel()
            {
                CurrentBlock = earliestSyncedBlockHeight,
                LatestBlockHeight = (await blockInfoProvider.GetLatestBlockInfoAsync()).BlockNumber
            };
        }

        public IEnumerable<DataPoint> GetTPSAt(long timestamp, string network, int count)
        {
            throw new NotImplementedException();
        }
    }
}
