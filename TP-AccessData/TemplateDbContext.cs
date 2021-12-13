using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.Entities;

namespace TP_AccessData
{
   public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {

        }

        public DbSet<Turno> Turnos { get; set; }
        public DbSet<CalendarioTurnos> CalendarioTurnos { get; set; }
        public DbSet<Dia> Dias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dia>().HasData(
              new Dia { Id = 1, Nombre = "Lunes"},
              new Dia { Id = 2,Nombre = "Martes"},
              new Dia { Id = 3,Nombre = "Miercoles"},
              new Dia { Id = 4,Nombre = "Jueves"},
              new Dia { Id = 5,Nombre = "Viernes"},
              new Dia { Id = 6, Nombre = "Sabado" },
              new Dia { Id = 7, Nombre = "Domingo" }
            );

        }
   }
}
