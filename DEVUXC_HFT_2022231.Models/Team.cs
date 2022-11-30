using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DEVUXC_HFT_2022231.Models.Useless;

namespace DEVUXC_HFT_2022231.Models
{
    [Table("sponsors")]
    public class Team : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<Driver> Drivers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sponsor> Sponsors { get; set; }
        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public Team()
        {
            Drivers= new List<Driver>();
            Sponsors= new HashSet<Sponsor>();
        }
        public override bool Equals(Object obj)
        {
            var b = obj as Team;
            if (b.Name == this.Name) { return true; }
            else { return false; }
        }


    }
}
