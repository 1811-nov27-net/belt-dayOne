using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureREST.Models
{
    public class Temperature
    {
        public enum TemperatureUnit
        {
            Fahrenheit, Celsius
        }
        [Required]
        public int? ID{ get; set; }
        [Required]
        public DateTime? Time { get; set; }
        [Required]
        [Range(-200, 1000)]
        public double? Value { get; set; }
        [Required]
        public TemperatureUnit? Unit { get; set; }
    }
}
