using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    public class Driver : Entity
    {
        public Driver(int id, string name, int driverNumber, string country, DateTime birth, int points = 0,  int worldChampTitles = 0)
        {
            Id = id;
            Name = name;
            DriverNumber = driverNumber;
            Country = country;
            Points = points;
            Birth = birth;
            WorldChampTitles = worldChampTitles;
        }

        [Key]
        public override int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(2)]
        [Required]
        public int DriverNumber { get; set; }
        [MaxLength(20)]
        [Required]
        public string Country { get; set; }
        public int Points { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        public int WorldChampTitles { get; set; }

    }
}
