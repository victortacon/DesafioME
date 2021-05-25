using DesafioME.Webapi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DesafioME.Webapi.Data
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasMany(i => i.Itens)
                .WithOne(p => p.Pedido)
                .HasForeignKey(k => k.pedidoId);

            modelBuilder.Entity<Pedido>().HasKey(k => k.pedido);

            modelBuilder.Entity<Pedido>().HasMany(i => i.StatusPedidos)
                .WithOne(p => p.Pedido)
                .HasForeignKey(k => k.pedido);

            modelBuilder.Entity<Item>().HasKey(k => k.idItem);

            modelBuilder.Entity<StatusPedido>().HasKey(k => k.idStatus);


        }


    }
}
