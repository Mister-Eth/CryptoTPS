using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Database
{
    public partial class Provider
    {
        public Provider()
        {
            OldestLoggedHistoricalEntries = new HashSet<OldestLoggedHistoricalEntry>();
            OldestLoggedTimeWarpBlocks = new HashSet<OldestLoggedTimeWarpBlock>();
            TimeWarpData = new HashSet<TimeWarpDatum>();
            TimeWarpDataDays = new HashSet<TimeWarpDataDay>();
            TimeWarpDataHours = new HashSet<TimeWarpDataHour>();
            TimeWarpDataMinutes = new HashSet<TimeWarpDataMinute>();
            TimeWarpDataWeeks = new HashSet<TimeWarpDataWeek>();
            TpsDataAlls = new HashSet<TpsDataAll>();
            TpsDataDays = new HashSet<TpsDataDay>();
            TpsDataHours = new HashSet<TpsDataHour>();
            TpsDataLatests = new HashSet<TpsDataLatest>();
            TpsDataMaxes = new HashSet<TpsDataMax>();
            TpsDataMonths = new HashSet<TpsDataMonth>();
            TpsDataWeeks = new HashSet<TpsDataWeek>();
            TpsDataYears = new HashSet<TpsDataYear>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Color { get; set; }
        public int TheoreticalMaxTps { get; set; }
        public int? IsGeneralPurpose { get; set; }
        public int? HistoricalAggregationDeltaBlock { get; set; }
        public bool Enabled { get; set; }

        public virtual ProviderType TypeNavigation { get; set; }
        public virtual ICollection<OldestLoggedHistoricalEntry> OldestLoggedHistoricalEntries { get; set; }
        public virtual ICollection<OldestLoggedTimeWarpBlock> OldestLoggedTimeWarpBlocks { get; set; }
        public virtual ICollection<TimeWarpDatum> TimeWarpData { get; set; }
        public virtual ICollection<TimeWarpDataDay> TimeWarpDataDays { get; set; }
        public virtual ICollection<TimeWarpDataHour> TimeWarpDataHours { get; set; }
        public virtual ICollection<TimeWarpDataMinute> TimeWarpDataMinutes { get; set; }
        public virtual ICollection<TimeWarpDataWeek> TimeWarpDataWeeks { get; set; }
        public virtual ICollection<TpsDataAll> TpsDataAlls { get; set; }
        public virtual ICollection<TpsDataDay> TpsDataDays { get; set; }
        public virtual ICollection<TpsDataHour> TpsDataHours { get; set; }
        public virtual ICollection<TpsDataLatest> TpsDataLatests { get; set; }
        public virtual ICollection<TpsDataMax> TpsDataMaxes { get; set; }
        public virtual ICollection<TpsDataMonth> TpsDataMonths { get; set; }
        public virtual ICollection<TpsDataWeek> TpsDataWeeks { get; set; }
        public virtual ICollection<TpsDataYear> TpsDataYears { get; set; }
    }
}
