﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Database
{
    public abstract class TimeWarpDataBase
    {
        public int Id { get; set; }
        public int Network { get; set; }
        public int Provider { get; set; }
        public int? Block { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageTps { get; set; }

        public virtual Network NetworkNavigation { get; set; }
        public virtual Provider ProviderNavigation { get; set; }
    }

    public partial class TimeWarpDataWeek : TimeWarpDataBase { }
    public partial class TimeWarpDataHour : TimeWarpDataBase { }
    public partial class TimeWarpDataMinute : TimeWarpDataBase { }
    public partial class TimeWarpDataDay: TimeWarpDataBase { }
    public partial class TimeWarpDatum : TimeWarpDataBase { }
}
