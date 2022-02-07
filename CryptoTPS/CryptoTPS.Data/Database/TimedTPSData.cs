using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database
{
    public abstract class TimedTPSData : TPSDataBase
    {
        public DateTime StartDate { get; set; }
        public double AverageTps { get; set; }
        public int ReadingsCount { get; set; }
    }

    public class TpsDataDay : TimedTPSData { }
    public class TpsDataHour : TimedTPSData { }
    public class TpsDataWeek : TimedTPSData { }
    public class TpsDataMonth : TimedTPSData { }
    public class TpsDataAll : TimedTPSData { }
    public class TpsDataYear : TimedTPSData { }
}
