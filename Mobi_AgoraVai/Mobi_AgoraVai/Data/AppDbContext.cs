using System;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using Mobi_AgoraVai.Models;
using Microsoft.EntityFrameworkCore;

namespace Mobi_AgoraVai.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Calculadora> Calculadoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais, se necessário
        }
    }

}
