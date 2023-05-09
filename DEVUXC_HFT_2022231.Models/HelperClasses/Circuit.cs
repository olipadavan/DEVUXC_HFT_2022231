using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DEVUXC_HFT_2022231.Models.Useless;

namespace DEVUXC_HFT_2022231.Models
{
    [Table("circuits")]
    public class Circuit : Entity
    {
        [ForeignKey(nameof(Race))]
        public int RaceId { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public int Laps { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual Race Race { get; set; }
        [Key]
        public override int Id { get; set; }
        public Circuit()
        {

        }
    }
}
