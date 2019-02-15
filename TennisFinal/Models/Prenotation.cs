using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TennisFinal.Models
{
    public class Prenotation
    {
        [Key]
        public int Id_Prenotazione { get; set; }

        [Required]
        public string Campo { get; set; }

        [DateAttribute()]
        [Required]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required]
        public string Partita { get; set; }

        public class DateAttribute : RangeAttribute
        {
            public DateAttribute()
              : base(typeof(DateTime), DateTime.Now.ToShortDateString(), DateTime.Now.AddYears(1).ToShortDateString()) { }
        }

    }
}
