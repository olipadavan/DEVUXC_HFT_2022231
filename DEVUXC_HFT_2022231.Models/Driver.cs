using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    public class Driver : Entity
    {
        public Driver(int id = default, string name = "", int driverNumber =  0, string country = "",
               int points = 0,  int worldChampTitles = 0)
        {
            if (id == 0)
            {
                Id = IdGenerator(this);
            }
            Id = id;
            Name = name;
            DriverNumber = driverNumber;
            Country = country;
            Points = points;
            WorldChampTitles = worldChampTitles;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(2)]
        public int DriverNumber { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
        public int Points { get; set; }
        public DateTime Birth { get; set; }
        public int WorldChampTitles { get; set; }
    }
}
