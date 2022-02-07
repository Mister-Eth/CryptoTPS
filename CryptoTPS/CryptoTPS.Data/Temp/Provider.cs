using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Temp
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
            TpsdataAlls = new HashSet<TpsdataAll>();
            TpsdataDays = new HashSet<TpsdataDay>();
            TpsdataHours = new HashSet<TpsdataHour>();
            TpsdataMonths = new HashSet<TpsdataMonth>();
            TpsdataWeeks = new HashSet<TpsdataWeek>();
            TpsdataYears = new HashSet<TpsdataYear>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Color { get; set; }
        public bool? IsGeneralPurpose { get; set; }
        public int? HistoricalAggregationDeltaBlock { get; set; }
        public bool Enabled { get; set; }

        public virtual TpsdataLatest TpsdataLatest { get; set; }
        public virtual TpsdataMax TpsdataMax { get; set; }
        public virtual ICollection<OldestLoggedHistoricalEntry> OldestLoggedHistoricalEntries { get; set; }
        public virtual ICollection<OldestLoggedTimeWarpBlock> OldestLoggedTimeWarpBlocks { get; set; }
        public virtual ICollection<TimeWarpDatum> TimeWarpData { get; set; }
        public virtual ICollection<TimeWarpDataDay> TimeWarpDataDays { get; set; }
        public virtual ICollection<TimeWarpDataHour> TimeWarpDataHours { get; set; }
        public virtual ICollection<TimeWarpDataMinute> TimeWarpDataMinutes { get; set; }
        public virtual ICollection<TimeWarpDataWeek> TimeWarpDataWeeks { get; set; }
        public virtual ICollection<TpsdataAll> TpsdataAlls { get; set; }
        public virtual ICollection<TpsdataDay> TpsdataDays { get; set; }
        public virtual ICollection<TpsdataHour> TpsdataHours { get; set; }
        public virtual ICollection<TpsdataMonth> TpsdataMonths { get; set; }
        public virtual ICollection<TpsdataWeek> TpsdataWeeks { get; set; }
        public virtual ICollection<TpsdataYear> TpsdataYears { get; set; }
    }
}
