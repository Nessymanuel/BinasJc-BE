using BinasJc.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace BinasJc.DAL.Context
{
    public class BinasJcContext : DbContext
    {
        public BinasJcContext(DbContextOptions<BinasJcContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estacao> Estacoes { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Mensagem> Mensagem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            // Configuração de Reserva: EstacaoRetirada e EstacaoDevolucao
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.EstacaoRetirada)
                .WithMany()
                .HasForeignKey(r => r.EstacaoRetiradaID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.EstacaoDevolucao)
                .WithMany()
                .HasForeignKey(r => r.EstacaoDevolucaoID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de Reserva: Bicicleta
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Bicicleta)
                .WithMany()
                .HasForeignKey(r => r.BicicletaID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de Reserva: Usuario
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de Ponto: UsuarioOrigem e UsuarioDestino
            modelBuilder.Entity<Ponto>()
                .HasOne(p => p.UsuarioOrigem)
                .WithMany()
                .HasForeignKey(p => p.UsuarioOrigemID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ponto>()
                .HasOne(p => p.UsuarioDestino)
                .WithMany()
                .HasForeignKey(p => p.UsuarioDestinoID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de Bicicleta: Estacao
            modelBuilder.Entity<Bicicleta>()
                .HasOne(b => b.Estacao)
                .WithMany()
                .HasForeignKey(b => b.EstacaoID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurações de precisão para decimal
            modelBuilder.Entity<Estacao>()
                .Property(e => e.Latitude)
                .HasColumnType("decimal(9,6)");

            modelBuilder.Entity<Estacao>()
                .Property(e => e.Longitude)
                .HasColumnType("decimal(9,6)");

            modelBuilder.Entity<Reserva>()
                .Property(r => r.DistanciaPercorrida)
                .HasColumnType("decimal(5,2)");

            base.OnModelCreating(modelBuilder);
        }

    }
}

