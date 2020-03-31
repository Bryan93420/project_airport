using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace JC.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
        public MyAirportContext(DbContextOptions<MyAirportContext> options) : base(options) 
        { }

        public DbSet<Vol> Vols { get; set; }
        public DbSet<Bagage> Bagages { get; set; }

        public static readonly ILoggerFactory MyAirportLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirportContext"].ConnectionString);
            optionsBuilder.UseLoggerFactory(MyAirportLoggerFactory);

        }*/
    }
}
