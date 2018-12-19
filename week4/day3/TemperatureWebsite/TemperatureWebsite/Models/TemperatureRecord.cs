using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureWebsite.Models
{
    public class TemperatureRecord
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public double Value { get; set; }

        public int Unit { get; set; }

        public string UnitName => GetUnitName(Unit);

        public static string GetUnitName(int id)
        {
            switch(id)
            {
                case 1:
                    return "Celsius";
                case 2:
                    return "Farenheit";
                default:
                    return null;
            }
        }
    }
}
