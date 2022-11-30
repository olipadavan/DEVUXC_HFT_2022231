using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DEVUXC_HFT_2022231.Models.Useless;

namespace DEVUXC_HFT_2022231.Models
{
    [Table("races")]
    public class Race : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        [NotMapped]
        [MaxLength(20)]
        public virtual ICollection<Driver> Drivers { get; set; }
        public DateTime RaceDate { get; set; }
        public string Country { get; set; }
        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Season Season { get; set; }
        
    }
}
