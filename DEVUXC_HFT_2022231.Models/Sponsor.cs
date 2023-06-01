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
    public class Sponsor : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Team Team { get; set; }
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }

        public override bool Equals(Object obj)
        {
            var b = obj as Team;
            var answer = b != null ? b.Name == this.Name : false;
            if (answer) { return true; }
            else { return false; }
        }
    }
}
