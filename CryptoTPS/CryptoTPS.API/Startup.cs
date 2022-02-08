

using CryptoTPS.API.Middlewares;
using CryptoTPS.Services;
using CryptoTPS.Services.Infrastructure.Extensions;
using CryptoTPS.Data.Database;

using Hangfire;
using Hangfire.SqlServer;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Linq;
using CryptoTPS.Services.BlockchainServices;
using CryptoTPS.Services.BlockchainServices.Scan;
using CryptoTPS.Data.Database.HistoricalDataProviders;
using CryptoTPS.API.Infrastructure.Services;
using CryptoTPS.API.Infrastructure.Services.Implementations;
using CryptoTPS.Services.BlockchainServices.Status;
using CryptoTPS.Services.BlockchainServices.Status.BackgroundTasks.Discord;
using CryptoTPS.Services.BlockchainServices.BlockTime;

namespace CryptoTPS.API
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string[] ConfigurationQueues => Configuration.GetSection("Hangfire").GetSection("Queues").Get<string[]>();

        public void ConfigureServices(IServiceCollection services)
        {
            var defaultConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://CryptoTPS.info");
                                      builder.WithOrigins("http://localhost:4007");
                                      builder.AllowAnyHeader();
                                  });
            });

            services.AddControllers().AddNewtonsoftJson().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddDbContext<CryptoTPSContext>(options => options.UseSqlServer(defaultConnectionString), ServiceLifetime.Transient);
            services.AddMemoryCache();

            AddServices(services);
            AddHistoricalDataProviders(services);
            if (ConfigurationQueues?.Length > 0)
            {
                InitializeHangFire(defaultConnectionString);
                services.AddHangfire(x => x.UseSqlServerStorage(defaultConnectionString));
                services.AddHangfireServer();
                AddTPSDataUpdaters(services);
                AddCacheUpdaters(services);
                AddHistoricalBlockInfoDataUpdaters(services);
                AddTimeWarpUpdaters(services);
                AddStatusNotifiers(services);
            }
           
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<TPSService>();
            services.AddScoped<GeneralService>();
            services.AddScoped<TimeWarpService>();
            services.AddScoped<IBlockInfoProviderStatusService, BlockInfoProviderStatusService>();
            services.AddScoped<EthereumBlockTimeProvider>();
        }

        private void AddHistoricalBlockInfoDataUpdaters(IServiceCollection services)
        {
            if (ConfigurationQueues.Contains(HISTORICALUPDATERQUEUE))
            {

            }
        }

        private void AddTPSDataUpdaters(IServiceCollection services)
        {
            if (ConfigurationQueues.Contains(TPSUPDATERQUEUE))
            {

            }
        }

        private void AddCacheUpdaters(IServiceCollection services)
        {
            if (ConfigurationQueues.Contains(CACHEUPDATERQUEUE))
            {
                
            }
        }

        private void AddStatusNotifiers(IServiceCollection services)
        {
            if (ConfigurationQueues.Contains(STATUSUPDATERQUEUE))
            {
                //services.RegisterHangfireBackgroundService<APIStatusBackgroundTask>(CronConstants.EveryMinute, STATUSUPDATERQUEUE);
                //services.RegisterHangfireBackgroundService<WebsiteStatusBackgroundTask>(CronConstants.EveryMinute, STATUSUPDATERQUEUE);
                //services.RegisterHangfireBackgroundService<UpdaterStatusBackgroundTask>(CronConstants.EveryMinute, STATUSUPDATERQUEUE);
                services.RegisterHangfireBackgroundService<PlausibleVisitorCountBackgroundTask>(CronConstants.EveryMidnight, STATUSUPDATERQUEUE);
            }
        }

        private void AddTimeWarpUpdaters(IServiceCollection services)
        {
            if (ConfigurationQueues.Contains(TIMEWARPUPDATERQUEUE))
            {

            }
        }

        private void AddHistoricalDataProviders(IServiceCollection services)
        {
            services.AddScoped<IHistoricalDataProvider, OneHourHistoricalDataProvider>();
            services.AddScoped<IHistoricalDataProvider, OneDayHistoricalDataProvider>();
            services.AddScoped<IHistoricalDataProvider, OneWeekHistoricalDataProvider>();
            services.AddScoped<IHistoricalDataProvider, OneMonthHistoricalDataProvider>();
            services.AddScoped<IHistoricalDataProvider, OneYearHistoricalDataProvider>();
            services.AddScoped<IHistoricalDataProvider, AllHistoricalDataProvider>();
        }

        public static void InitializeHangFire(string connectionString)
        {
            var sqlStorage = new SqlServerStorage(connectionString);
            JobStorage.Current = sqlStorage;
        }

        private const string TPSUPDATERQUEUE = "tpsdata";
        private const string CACHEUPDATERQUEUE = "cache";
        private const string STATUSUPDATERQUEUE = "status";
        private const string HISTORICALUPDATERQUEUE = "historical";
        private const string TIMEWARPUPDATERQUEUE = "timewarp";

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseMiddleware<AccesStatsMiddleware>();
            // GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(serviceProvider));
            if (ConfigurationQueues?.Length > 0)
            {
                app.UseHangfireServer(options: new BackgroundJobServerOptions()
                {
                    Queues = ConfigurationQueues ?? new string[] { "default" }
                });
                if (Configuration.GetSection("Hangfire").GetValue<bool>("Show"))
                {
                    app.UseHangfireDashboard();
                }
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoTPS API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
