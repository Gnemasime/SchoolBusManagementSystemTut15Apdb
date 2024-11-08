using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolBusManagementSystemTut15Apdb.Models
{
    public class BusDriverPerfomanceViewModel
    {
        [Key]
        public int BusDriverId { get; set; }
        public string DriverName { get; set; }
        public int PointsEarned { get; set; }
        public string LicenseType { get; set; }
        public decimal TotalEarnings { get; set; }
        public int AverateRatings { get; set; }
    }
}