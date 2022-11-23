using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    [Table("circuits")]
    public class Circuit : Entity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public int Laps { get; set; }
        [JsonIgnore]
        public virtual Race Race { get; set; }
        [ForeignKey(nameof(Race))]
        public int RaceId { get; set; }
        public Circuit()
        {

        }
    }
}
