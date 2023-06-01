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
    [Table("seasons")]
    public class Season : Entity
    {
        public Season()
        {
            Teams = new HashSet<Team>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public int SeasonYear { get; set; }
        //public virtual ICollection<Race> Races { get; set; }
        //public virtual ICollection<Driver> Drivers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }
        
        public override bool Equals(Object obj)
        {
            var b = obj as Season;
            var response = b != null? b.Id == this.Id : false;
            if (response) { return true; }
            else { return false; }
        }
    }
}
