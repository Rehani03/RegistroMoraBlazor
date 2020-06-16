using Microsoft.EntityFrameworkCore;
using RegistroMoraBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroMoraBlazor.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\MoraDB.db");
        }

        public DbSet<Prestamo> Prestamos { get; set;}
        public DbSet<Mora> Moras { get; set; }
    }
}
