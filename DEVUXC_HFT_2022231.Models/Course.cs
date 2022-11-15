using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    public class Course : Entity
    {
        public override int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Length { get; set; }
        public int Laps { get; set; }
        public virtual Race Race { get; set; }
        public int RaceId { get; set; }
    }
}
