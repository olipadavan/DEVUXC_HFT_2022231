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
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        protected static int staticDriverId = 0;
        protected static int staticRaceId = 0;
        protected static int staticSeasonId = 0;
        protected static int staticCourseId = 0;
        protected DateTime dt = new DateTime();
        public static int IdGenerator(object thisobj)
        {
            if (thisobj is Season)
            {
                return staticSeasonId++;
            }
            else if (thisobj is Driver)
            {
                return staticDriverId++;
            }
            else if (thisobj is Race)
            {
                return staticRaceId++;
            }
            else if (thisobj is Circuit)
            {
                return staticCourseId++;
            }
            else
            {
                throw new ArgumentException("This object has no ID generator");
            }
        }

        public static DateTime ToDatetime(int y, int m, int d)
        {
            DateTime date = new DateTime(y, m, d);
            return date;
        }

    }
}
