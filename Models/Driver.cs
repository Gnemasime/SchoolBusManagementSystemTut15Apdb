using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //PrimaryKey
using System.ComponentModel.DataAnnotations.Schema; // autogeneration
using System.Linq;
using System.Web;

namespace SchoolBusManagementSystemTut15Apdb.Models
{
    public class Driver
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Driverid { get; set; }
        public string Name { get; set; }
        public string LicenseType { get; set; }
        public int AssignedBusId { get; set; }
        public int DriverScore { get; set; }
        public decimal Salary { get; set; }

    }
}