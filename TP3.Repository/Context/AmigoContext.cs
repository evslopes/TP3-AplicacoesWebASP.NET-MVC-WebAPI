using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TP3.Domain;
using TP3.Repository.Mapping;

namespace TP3.Repository.Context
{
    public class AmigoContext : DbContext
    {
        public DbSet<Amigo> Amigos { get; set; }

        public static readonly ILoggerFactory _loggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public AmigoContext(DbContextOptions<AmigoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmigoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
