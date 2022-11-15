using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    [Table("races")]
    public class Race : Entity
    {
        [Key]
        public override int Id { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Driver> Drivers { get; set; }
        public int[] DriverIds { get; set; }
        public int[] RaceResult { get; set; }
        public DateTime RaceDate { get; set; }
        public string Country { get; set; }
        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }
        [NotMapped]
        public virtual Season Season { get; set; }
        public Race()
        {
            this.Drivers = new HashSet<Driver>();
        }

        public Race(int id, ICollection<Driver> drivers,
            int[] raceResult, DateTime raceDate, string country, int seasonId, 
            Season season)
        {
            Id = id;
            Drivers = drivers;
            RaceResult = raceResult;
            RaceDate = raceDate;
            Country = country;
            SeasonId = seasonId;
            Season = season;
        }
    }
}
