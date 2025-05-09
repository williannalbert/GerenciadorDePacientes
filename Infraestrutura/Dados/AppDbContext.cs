using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Dados;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Convenio> Convenios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Sobrenome).IsRequired().HasMaxLength(255);
            entity.Property(p => p.CPF).IsRequired().HasMaxLength(11);
            entity.Property(p => p.RG).IsRequired().HasMaxLength(20);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Celular).IsRequired().HasMaxLength(11);
            entity.Property(p => p.TelefoneFixo).HasMaxLength(10);
            entity.Property(p => p.NumeroCarteirinha).IsRequired().HasMaxLength(30);
            entity.Property(p => p.ValidadeCarteirinha).IsRequired().HasMaxLength(5);

            entity.HasOne(p => p.Convenio)
                  .WithMany(c => c.Pacientes)
                  .HasForeignKey(p => p.ConvenioId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Convenio>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        });
    }
}
