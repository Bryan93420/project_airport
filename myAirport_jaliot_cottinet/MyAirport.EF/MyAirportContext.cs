using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JC.MyAirport.EF
{
    class MyAirportContext : DbContext
    {
            public DbSet<Vol> Vols { get; set; }
            public DbSet<Bagage> Bagages { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
            }
    }
}
