using System;
using CarRentalApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Infrastructure
{
    public class CarRentalDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Automovel> Automoveis { get; set; }

        public DbSet<Contrato> Contratos { get; set; }

        public DbSet<ContratoAutomovel> ContratoAutomoveis { get; set; }

        public DbSet<UserProprietario> Proprietarios { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Localidade> Localidades { get; set; }

        public string DbPath { get; set; }

        public CarRentalDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}CarReserve.db";

            //DbPath = System.IO.Path.Join(path, "CarReserve.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) { options.UseSqlite($"Data Source={DbPath}"); }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Categoria>().HasIndex(c => c.Name).IsUnique();        
            mb.Entity<Categoria>().Property(c => c.Name).IsRequired().HasMaxLength(256);   

            mb.Entity<Automovel>().HasIndex(a => a.Matricula).IsUnique();       
            mb.Entity<Automovel>().Property(a => a.Matricula).IsRequired().HasMaxLength(256);          

            mb.Entity<Localidade>().HasIndex(l => l.CodPostal).IsUnique();
            mb.Entity<Localidade>().Property(l => l.CodPostal).IsRequired().HasMaxLength(256);

            mb.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            mb.Entity<User>().Property(u => u.UserName)
                .IsRequired().HasMaxLength(256);
            mb.Entity<User>().Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(256);
            mb.Entity<User>().Property(x => x.IsAdmin)
                .IsRequired();

            mb.Entity<UserProprietario>().HasIndex(us => us.Name).IsUnique();
            mb.Entity<UserProprietario>().Property(us => us.Name).IsRequired().HasMaxLength(256);

            //   mb.Entity<Contrato>().
            mb.Entity<Contrato>().HasIndex(nc => nc.NumContrato).IsUnique();
            mb.Entity<Contrato>().Property(nc => nc.NumContrato).IsRequired();


            //Verificar se a categoria 
            mb.Entity<Automovel>()
                .HasOne(c => c.Categoria)                // no Automovel está associado uma categoria
                .WithMany(a => a.Automoveis)              //Com muitos automoveis em uma catgr.
                .HasForeignKey(c => c.CategoriaId)       //estar associado a uma categoria
                .OnDelete(DeleteBehavior.Restrict);     // (DeleteBehavior.Restrict--Não permite que o pai seja excluído)

            mb.Entity<User>()
                .HasOne(l => l.Localidade)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.LocalidadeId)
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Automovel>()
                .HasOne(us => us.Proprietario)
                .WithMany(a => a.Automoveis)
                .HasForeignKey(us => us.ProprietarioId)
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<ContratoAutomovel>().HasKey(ca => new { ca.ContratoId, ca.AutomovelId });

            mb.Entity<ContratoAutomovel>()
                .HasOne<Contrato>(ca => ca.Contrato)
                .WithMany(s => s.ContratoAutomoveis)
                .HasForeignKey(ca => ca.ContratoId);

            mb.Entity<User>()
                .HasOne<UserProprietario>(u => u.Proprietario)
                .WithOne(us => us.User);
            mb.Entity<Contrato>()
                .HasOne(u => u.User)
                .WithMany(c => c.Contratos)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
