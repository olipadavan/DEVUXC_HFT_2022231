using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Models
{
    public abstract class Entity : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        
        protected DateTime dt = new DateTime();
        
        public static DateTime ToDatetime(int y, int m, int d)
        {
            DateTime date = new DateTime(y, m, d);
            return date;
        }

    }
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
