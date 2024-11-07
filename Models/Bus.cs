using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolBusManagementSystemTut15Apdb.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        public string BusType { get; set; }
        public int MaxSeats { get; set; }
        public decimal CurrentFuelLevel { get; set; }
        public decimal RatePerStudent { get; set; }
    }
}