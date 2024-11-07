using System;
using System.Collections.Generic;
using System.Data.Entity; //DbConext
using System.Linq;
using System.Web;

namespace SchoolBusManagementSystemTut15Apdb.Models
{
    public class SchoolBusContext : DbContext
    {
        public SchoolBusContext(): base("DefaultConnnection") { }

        public DbSet<Bus> buses { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Trip> trips { get; set; }
    }
}