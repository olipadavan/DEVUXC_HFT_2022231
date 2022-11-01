using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    public class Race : Entity
    {
        public Race(int id, IEnumerable<Driver> drivers, IEnumerable<Driver> qualifyingResult, 
            IEnumerable<Driver> raceResult, DateTime raceDate, string circuitName)
        {
            Id =id;
            Drivers = drivers;
            QualifyingResult = qualifyingResult;
            RaceResult = raceResult;
            RaceDate = raceDate;
            CircuitName = circuitName;
        }

        [Key]
        public override int Id { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Driver> QualifyingResult { get; set; }
        public IEnumerable<Driver> RaceResult { get; set; }
        public DateTime RaceDate { get; set; }
        public string CircuitName { get; set; }

    }
}
