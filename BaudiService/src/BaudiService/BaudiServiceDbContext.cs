
using BaudiService.Models;
using System;
using System.Data;
using System.Data.Entity;


namespace BaudiService
{
    public class BaudiServiceDbContext : DbContext
    {
        public DbSet<Building> Building { get; set; }
        public DbSet<CyclicOrder> CyclicOrder { get; set; }
        public DbSet<Inhabitancy> Inhabitancy { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderType> OrderType { get; set; }
        public DbSet<OrderType> Owner { get; set; }
        public DbSet<OrderType> Ownership { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public BaudiServiceDbContext() : base("Data Source =.\\sqlexpress; Initial Catalog = BaudiDB; Integrated Security = True;") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            builder.Entity<Building>(a =>
            {
                a.HasMany(b => b.Locals)
                .WithOne(l => l.Building)
                .Required();

                a.HasMany(b => b.Notifactions)
                .WithOne(n => n.Building)
                .Required(false);

                a.HasMany(b => b.CyclicOrders)
                .WithOne(c => c.Building)
                .Required(false);

            });


            builder.Entity<Local>(a =>
            {
                a.HasMany(l => l.Inhabitancies)
                .WithOne(i => i.Local)
                .Required();

                a.HasMany(l => l.Ownerships)
                .WithOne(o => o.Local)
                .Required(false);

                a.HasMany(b => b.Payments)
                .WithOne(p => p.Local)
                .Required(false);


            });

            builder.Entity<Owner>().ToTable("student");


        }

    }
}