using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    public class Season
    {
        public Season(int seasonYear, IEnumerable<Race> races, IEnumerable<Driver> drivers, IEnumerable<int> standing)
        {
            Id = seasonYear;
            Races = races;
            Drivers = drivers;
            Standing = standing;
        }

        [Key]
        public int Id { get; set; }
        public IEnumerable<Race> Races { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<int> Standing { get; set; }
    }
}
