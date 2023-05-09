using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models.Useless
{
    public class Driver
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(2)]
        public int DriverNumber { get; set; }
    }
    
}
