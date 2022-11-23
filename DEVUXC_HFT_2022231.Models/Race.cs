using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    [Table("races")]
    public class Race : Entity
    {
        [Key]
        public override int Id { get; set; }
        [NotMapped]
        [MaxLength(20)]
        public virtual ICollection<Driver> Drivers { get; set; }
        public DateTime RaceDate { get; set; }
        public string Country { get; set; }
        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }
        [NotMapped]
        public virtual Season Season { get; set; }
        public virtual Circuit Circuit { get; set; }
        [ForeignKey(nameof(Circuit))]
        public int CircuitId { get; set; }
        
        public Race(ICollection<Driver> drivers, DateTime raceDate, string country, int seasonId, 
            Season season, int id = default)
        {
            if (id == default)
            {
                id = IdGenerator(this);
            }
            else
            {
                Id = id;
            }
            Drivers = drivers;
            RaceDate = raceDate;
            Country = country;
            SeasonId = seasonId;
            Season = season;
            this.Drivers = new HashSet<Driver>();
        }
        public Race()
        {

        }
        
    }
}
