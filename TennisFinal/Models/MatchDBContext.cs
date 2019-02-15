using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisFinal.Models
{
    public class MatchDBContext : DbContext
    {
        public virtual DbSet<Prenotation> Prenotations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-2N0J4TUT;
                                            Initial Catalog=Tennis;
                                            Integrated Security=True;
                                            MultipleActiveResultSets=true");
            }
        }
    }
}
