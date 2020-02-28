using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace JC.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
            public static readonly ILoggerFactory MyAirportLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });
            public DbSet<Vol> Vols { get; set; }
            public DbSet<Bagage> Bagages { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
            }
    }
}
