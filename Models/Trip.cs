using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Primary Key
using System.Linq;
using System.Web;

namespace SchoolBusManagementSystemTut15Apdb.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public int BusId { get; set; }
        public virtual Bus Bus { get; set; } // indicating a foreign key
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; } // indicating a foreign key
        public DateTime TripDate { get; set; }
        public int NumberOfStudents { get; set; }
        public decimal TripRevenue { get; set; }
        public bool IsCompleted { get; set; }
        public int Rating { get; set; }

        //method to add driver score
        public void AddDriverScore()
        {
            SchoolBusContext db = new SchoolBusContext();
            Driver driver = (from d in db.drivers
                             where d.Driverid == DriverId
                             select d).FirstOrDefault();

            driver.DriverScore += 20; // driver.DriverScore = driver.DriverScore + 20;
            db.SaveChanges();
        }

        //mthod to pull driver points
        public int PullDriverScore()
        {
            SchoolBusContext db = new SchoolBusContext();
            var score = (from s in db.drivers
                         where s.Driverid == DriverId
                         select s.DriverScore).FirstOrDefault();
            return score;
        }

        //method to calculate driver salary
        public decimal CalcDriverSalary()
        {
            if(PullDriverScore() >= 500)
            {
                return (PullDriverScore() / 500) * 200; // (2500 /500) * 200 = 1000
            }
            else
            {
                return 0;
            }
        }

        //method to pull rate per student
        public decimal PullRatePerStud()
        {
            SchoolBusContext db = new SchoolBusContext();
            var rate = (from a in db.buses
                        where a.BusId == BusId
                        select a.RatePerStudent).FirstOrDefault();

            return rate;
        }

        //method to calculate total revenue
        public decimal CalcTotalRevenue()
        {
            return NumberOfStudents * PullDriverScore();
        }

        //method for penalty
        public decimal ApplyPenalty()
        {
            if(Rating>=1 && Rating <3)
            {
                return CalcDriverSalary() - (CalcDriverSalary() * (2 / 100.0m));
            }
            else
            {
                return 0;
            }
        }

        //method for applying bonus 
        public void ApplyBonus()
        {
            SchoolBusContext db = new SchoolBusContext();
            Driver driver = (from d in db.drivers
                             where d.Driverid == DriverId
                             select d).FirstOrDefault();

            if(Rating > 3 && Rating <= 5)
            {
                driver.DriverScore += 30;
            }

            db.SaveChanges();
        }

    }
}