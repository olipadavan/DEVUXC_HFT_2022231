using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    [Table("seasons")]
    public class Season : Entity
    {
        public Season(int seasonYear)
        {
            SeasonYear = seasonYear;
            Races = new HashSet<Race>();
            Drivers = new HashSet<Driver>();
            Standing = new Point[20];
            Entity.staticSeasonId++;
        }

        public int SeasonYear { get; set; }
        public virtual ICollection<Race> Races { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual Point[] Standing { get; set; } //Driver number | point amount

    }
    
    public class Point
    {
        public Point(int driverNumber, int points)
        {
            DriverNumber = driverNumber;
            this.points = points;
        }
        [Key]
        public int DriverNumber { get; set; }
        public int points { get; set; }
        public static int[] availablePoints = { 25, 18, 15, 12,10, 8, 6, 4, 2, 1 };
    }
}
