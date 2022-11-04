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
            Standing = new double[Drivers.Count, 2];
        }

        [Key]
        public int SeasonYear { get; set; }
        public virtual ICollection<Race> Races { get; set; }
        public ICollection<Driver> Drivers { get; set; }
        public double[,] Standing { get; set; } //Driver number | point amount
    }
}
