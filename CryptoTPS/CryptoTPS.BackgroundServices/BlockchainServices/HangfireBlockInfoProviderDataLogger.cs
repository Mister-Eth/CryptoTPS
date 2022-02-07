using CryptoTPS.Data.Database;
using CryptoTPS.Services.BlockchainServices.Extensions;

using Hangfire;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices
{
    public class HangfireBlockInfoProviderDataLogger<T> : HangfireBackgroundService
        where T : IBlockInfoProvider
    {
        protected readonly T _instance;
        protected readonly string _provider;
        protected readonly int _providerID;

        public HangfireBlockInfoProviderDataLogger(T instance, ILogger<HangfireBackgroundService> logger, CryptoTPSContext context) : base(logger, context)
        {
            _instance = instance;
            _provider = _instance.GetProviderName();
            _providerID = _context.Providers.First(x => x.Name == _provider).Id;
        }

        [AutomaticRetry(Attempts = 1, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        public override async Task RunAsync()
        {
            try
            {
                var delta = await CalculateTPSAsync();
                UpdateMaxEntry(delta);
                UpdateLatestEntries(delta);

                AddOrUpdateHourTPSEntry(delta);
                AddOrUpdateDayTPSEntry(delta);
                AddOrUpdateWeekTPSEntry(delta);
                AddOrUpdateMonthTPSEntry(delta);
                AddOrUpdateYearTPSEntry(delta);
                AddOrUpdateAllTPSEntry(delta);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"{_provider}: {delta.TPS}TPS");
            }
            catch (Exception e)
            {
                _logger.LogError("TPSDataUpdaterBase", e);
                throw;
            }
        }

        private void UpdateLatestEntries(TPSInfo entry)
        {
            Func<TpsDataLatest, bool> selector = x => x.NetworkNavigation.Name == "Mainnet" && x.ProviderNavigation.Name == _provider;
            if (!_context.TpsDataLatests.Any(selector))
            {
                _context.TpsDataLatests.Add(new TpsDataLatest()
                {
                    Tps = entry.TPS,
                    Network = 1,
                    Provider = _providerID
                });
            }
            else
            {
                var x = _context.TpsDataLatests.First(selector);
                x.Tps = entry.TPS;
                _context.TpsDataLatests.Update(x);
            }
        }
        protected async Task<TPSInfo> CalculateTPSAsync() => await CalculateTPSAsync(await _instance.GetLatestBlockInfoAsync());
        protected async Task<TPSInfo> CalculateTPSAsync(int blockNumber) => await CalculateTPSAsync(await _instance.GetBlockInfoAsync(blockNumber));
        protected async Task<TPSInfo> CalculateTPSAsync(BlockInfo latestBlock)
        {
            if (_instance.BlockTimeSeconds > 0)
            {
                return new TPSInfo()
                {
                    BlockNumber = latestBlock.BlockNumber,
                    Date = latestBlock.Date,
                    TPS = latestBlock.TransactionCount / _instance.BlockTimeSeconds
                };
            }
            else //Add up all blocks submitted at the same time
            {
                var result = new TPSInfo()
                {
                    Date = latestBlock.Date
                };
                BlockInfo secondToLatestBlock;
                int count = 0;
                do
                {
                    result.TPS += latestBlock.TransactionCount;

                    secondToLatestBlock = await _instance.GetBlockInfoAsync(latestBlock.BlockNumber - 1);
                    if (secondToLatestBlock.Date.Subtract(latestBlock.Date).TotalSeconds != 0)
                    {
                        result.TPS /= Math.Abs(secondToLatestBlock.Date.Subtract(result.Date).TotalSeconds);
                        break;
                    }
                    latestBlock = secondToLatestBlock;
                    await Task.Delay(200);
                    if (++count == 100)
                    {
                        throw new Exception($"Possible infinite loop {(typeof(T))}");
                    }
                }
                while (true);
                return result;
            }
        }
        protected void UpdateMaxEntry(TPSInfo entry)
        {
            Func<TpsDataMax, bool> selector = x => x.ProviderNavigation.Name == _provider && x.NetworkNavigation.Name == "Mainnet";
            if (!_context.TpsDataMaxes.Any(selector))
            {
                _context.TpsDataMaxes.Add(new TpsDataMax()
                {
                    Date = entry.Date,
                    MaxTps = entry.TPS,
                    Network = 1,
                    Provider = _providerID
                });
            }
            else
            {
                var targetEntry = _context.TpsDataMaxes.First(selector);
                if (entry.TPS > targetEntry.MaxTps)
                {
                    targetEntry.MaxTps = entry.TPS;
                }
                _context.TpsDataMaxes.Update(targetEntry);
            }
        }

        protected void AddOrUpdateHourTPSEntry(TPSInfo entry)
        {
            var targetDate = entry.Date
                .Subtract(TimeSpan.FromSeconds(entry.Date.Second))
                .Subtract(TimeSpan.FromMilliseconds(entry.Date.Millisecond));
            Func<TpsDataHour, bool> selector = x => x.NetworkNavigation.Name == "Mainnet" && x.Provider == _providerID && x.StartDate.Minute == targetDate.Minute;
            if (!_context.TpsDataHours.Any(selector))
            {
                _context.TpsDataHours.Add(new TpsDataHour()
                {
                    Network = 1,
                    AverageTps = entry.TPS,
                    Provider = _providerID,
                    StartDate = targetDate,
                    ReadingsCount = 1
                });
            }
            else
            {
                var x = _context.TpsDataHours.First(selector);
                if (x.StartDate.Hour == targetDate.Hour)
                {
                    x.AverageTps = ((x.AverageTps * x.ReadingsCount) + entry.TPS) / ++x.ReadingsCount;
                }
                else
                {
                    x.AverageTps = entry.TPS;
                    x.ReadingsCount = 1;
                    x.StartDate = entry.Date;
                }
                _context.TpsDataHours.Update(x);
            }
        }
        protected void AddOrUpdateDayTPSEntry(TPSInfo entry)
        {
            var targetDate = entry.Date
                .Subtract(TimeSpan.FromSeconds(entry.Date.Second))
                .Subtract(TimeSpan.FromMilliseconds(entry.Date.Millisecond))
                .Subtract(TimeSpan.FromMinutes(entry.Date.Minute));
            Func<TpsDataDay, bool> selector = x => x.NetworkNavigation.Name == "Mainnet" && x.Provider == _providerID && x.StartDate.Hour == targetDate.Hour;
            if (!_context.TpsDataDays.Any(selector))
            {
                _context.TpsDataDays.Add(new TpsDataDay()
                {
                    Network = 1,
                    AverageTps = entry.TPS,
                    Provider = _providerID,
                    StartDate = targetDate,
                    ReadingsCount = 1
                });
            }
            else
            {
                var x = _context.TpsDataDays.First(selector);
                if (x.StartDate.Day == targetDate.Day)
                {
                    x.AverageTps = ((x.AverageTps * x.ReadingsCount) + entry.TPS) / ++x.ReadingsCount;
                }
                else
                {
                    x.AverageTps = entry.TPS;
                    x.ReadingsCount = 1;
                    x.StartDate = entry.Date;
                }
                _context.TpsDataDays.Update(x);
            }
        }
        protected void AddOrUpdateWeekTPSEntry(TPSInfo entry)
        {
            var targetDate = entry.Date
                .Subtract(TimeSpan.FromSeconds(entry.Date.Second))
                .Subtract(TimeSpan.FromMilliseconds(entry.Date.Millisecond))
                .Subtract(TimeSpan.FromMinutes(entry.Date.Minute));
            Func<TpsDataWeek, bool> selector = x => x.NetworkNavigation.Name == "Mainnet" && x.Provider == _providerID && x.StartDate.Hour == targetDate.Hour && x.StartDate.DayOfWeek == targetDate.DayOfWeek;
            if (!_context.TpsDataWeeks.Any(selector))
            {
                _context.TpsDataWeeks.Add(new TpsDataWeek()
                {
                    Network = 1,
                    AverageTps = entry.TPS,
                    Provider = _providerID,
                    StartDate = targetDate,
                    ReadingsCount = 1
                });
            }
            else
            {
                var x = _context.TpsDataWeeks.First(selector);
                if (x.StartDate.Day == targetDate.Day)
                {
                    x.AverageTps = ((x.AverageTps * x.ReadingsCount) + entry.TPS) / ++x.ReadingsCount;
                }
                else
                {
                    x.AverageTps = entry.TPS;
                    x.ReadingsCount = 1;
                    x.StartDate = entry.Date;
                }
                _context.TpsDataWeeks.Update(x);
            }
        }
        protected void AddOrUpdateMonthTPSEntry(TPSInfo entry)
        {
            var targetDate = entry.Date
                .Subtract(TimeSpan.FromSeconds(entry.Date.Second))
                .Subtract(TimeSpan.FromMilliseconds(entry.Date.Millisecond))
                .Subtract(TimeSpan.FromMinutes(entry.Date.Minute))
                .Subtract(TimeSpan.FromHours(entry.Date.Hour));
            Func<TpsDataMonth, bool> selector = x => x.NetworkNavigation.Name == "Mainnet" && x.Provider == _providerID && x.StartDate.Day == targetDate.Day;
            if (!_context.TpsDataMonths.Any(selector))
            {
                _context.TpsDataMonths.Add(new TpsDataMonth()
                {
                    Network = 1,
                    AverageTps = entry.TPS,
                    Provider = _providerID,
                    StartDate = targetDate,
                    ReadingsCount = 1
                });
            }
            else
            {
                var x = _context.TpsDataMonths.First(selector);
                if (x.StartDate.Month == targetDate.Month)
                {
                    x.AverageTps = ((x.AverageTps * x.ReadingsCount) + entry.TPS) / ++x.ReadingsCount;
                }
                else
                {
                    x.AverageTps = entry.TPS;
                    x.ReadingsCount = 1;
                    x.StartDate = entry.Date;
                }
                _context.TpsDataMonths.Update(x);
            }
        }

        protected void AddOrUpdateYearTPSEntry(TPSInfo entry)
        {
            var targetDate = entry.Date
                .Subtract(TimeSpan.FromSeconds(entry.Date.Second))
                .Subtract(TimeSpan.FromMilliseconds(entry.Date.Millisecond))
                .Subtract(TimeSpan.FromMinutes(entry.Date.Minute))
                .Subtract(TimeSpan.FromHours(entry.Date.Hour))
                .Subtract(TimeSpan.FromDays(entry.Date.Day))
                .Add(TimeSpan.FromDays(1));
            Func<TpsDataYear, bool> selector = x => x.NetworkNavigation.Name == "Mainnet" && x.Provider == _providerID && x.StartDate.Month == targetDate.Month;
            if (!_context.TpsDataYears.Any(selector))
            {
                _context.TpsDataYears.Add(new TpsDataYear()
                {
                    Network = 1,
                    AverageTps = entry.TPS,
                    Provider = _providerID,
                    StartDate = targetDate,
                    ReadingsCount = 1
                });
            }
            else
            {
                var x = _context.TpsDataYears.First(selector);
                if (x.StartDate.Year == targetDate.Year)
                {
                    x.AverageTps = ((x.AverageTps * x.ReadingsCount) + entry.TPS) / ++x.ReadingsCount;
                }
                else
                {
                    x.AverageTps = entry.TPS;
                    x.ReadingsCount = 1;
                    x.StartDate = entry.Date;
                }
                _context.TpsDataYears.Update(x);
            }
        }

        protected void AddOrUpdateAllTPSEntry(TPSInfo entry)
        {
            var targetDate = entry.Date
                .Subtract(TimeSpan.FromSeconds(entry.Date.Second))
                .Subtract(TimeSpan.FromMilliseconds(entry.Date.Millisecond))
                .Subtract(TimeSpan.FromMinutes(entry.Date.Minute))
                .Subtract(TimeSpan.FromHours(entry.Date.Hour))
                .Subtract(TimeSpan.FromDays(entry.Date.Day))
                .Add(TimeSpan.FromDays(1));
            Func<TpsDataAll, bool> selector = x => x.NetworkNavigation.Name == "Mainnet" && x.Provider == _providerID && x.StartDate.Month == targetDate.Month && x.StartDate.Year == targetDate.Year;
            if (!_context.TpsDataAlls.Any(selector))
            {
                _context.TpsDataAlls.Add(new TpsDataAll()
                {
                    Network = 1,
                    AverageTps = entry.TPS,
                    Provider = _providerID,
                    StartDate = targetDate,
                    ReadingsCount = 1
                });
            }
            else
            {
                var x = _context.TpsDataAlls.First(selector);
                x.AverageTps = ((x.AverageTps * x.ReadingsCount) + entry.TPS) / ++x.ReadingsCount;
                _context.TpsDataAlls.Update(x);
            }
        }
    }
}
