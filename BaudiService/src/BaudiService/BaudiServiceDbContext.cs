
using BaudiService.Models;
using System;
using System.Data;
using System.Data.Entity;


namespace BaudiService
{
    public class BaudiServiceDbContext : DbContext
    {
        //public DbSet<INotificationTarget> NotificationTargets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Local> Locals { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Rent> Rents { get; set; }

        //public DbSet<IExpenseTarget> ExpensesTarget {get; set;}
        public DbSet<CyclicOrder> CyclicOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Person> Peoples { get; set; }

        public DbSet<Notification> Notifications { get; set; }        
        public DbSet<OrderType> OrderTypes { get; set; }        
        public DbSet<Ownership> Ownerships { get; set; }        
        public DbSet<Specialization> Specializations { get; set; }

        public BaudiServiceDbContext() : base("Server=(localdb)\\MSSQLLocalDB;Database=BaudiDB;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
            //Database.SetInitializer<BaudiServiceDbContext>(new CreateDatabaseIfNotExists<BaudiServiceDbContext>());

            //Database.SetInitializer<BaudiServiceDbContext>(new DropCreateDatabaseIfModelChanges<BaudiServiceDbContext>());
            Database.SetInitializer<BaudiServiceDbContext>(new DropCreateDatabaseAlways<BaudiServiceDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().ToTable("Owners");

            modelBuilder.Entity<Employee>()
                .ToTable("Employees")
                .Map<Administrator>(m => m.Requires("Type").HasValue("Administrator"))
                .Map<Menager>(m => m.Requires("Type").HasValue("Menager"))
                .Map<Dispatcher>(m => m.Requires("Type").HasValue("Dispatcher"));

            modelBuilder.Entity<Building>().ToTable("Buildings");
            modelBuilder.Entity<Local>().ToTable("Locals");

            modelBuilder.Entity<Expense>().ToTable("Expenses");
            modelBuilder.Entity<Rent>().ToTable("Rents");

            modelBuilder.Entity<CyclicOrder>().ToTable("CyclicOrders");
            modelBuilder.Entity<Order>().ToTable("Orders");


            modelBuilder.Entity<Owner>().ToTable("Owners");
            modelBuilder.Entity<Person>().ToTable("Peoples");



            modelBuilder.Entity<Building>()
                .HasMany(b => b.Locals)
                .WithOptional(l => l.Building);
            modelBuilder.Entity<Building>()
                .HasMany(b => b.CyclicOrders)
                .WithRequired(c => c.Building);
            modelBuilder.Entity<Building>()
                .HasMany(b => b.Notifactions)
                .WithRequired(n => (Building)n.NotificationTarget);


            modelBuilder.Entity<Notification>()
                .HasMany(n => n.Orders)
                .WithRequired(o => o.Notification);

            modelBuilder.Entity<Local>()
                .HasMany(l => l.Ownerships)
                .WithRequired(o => o.Local);
            modelBuilder.Entity<Local>()
                .HasMany(l => l.Rents)
                .WithRequired(r => r.Local);
            modelBuilder.Entity<Local>()
                .HasMany(l => l.Notifactions)
                .WithRequired(n => (Local)n.NotificationTarget);

            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Ownerships)
                .WithOptional(o => o.Owner);
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Notifications)
                .WithOptional(n => n.Owner);

            modelBuilder.Entity<Dispatcher>()
                .HasMany(d => d.Notifications)
                .WithRequired(n => n.Dispatcher);

            modelBuilder.Entity<Menager>()
                .HasMany(m => m.Orders)
                .WithRequired(o => o.Menager);
            modelBuilder.Entity<Menager>()
                .HasMany(m => m.CyclicOrders)
                .WithRequired(c => c.Menager);
            modelBuilder.Entity<Menager>()
                .HasMany(m => m.MenagerExpenses)
                .WithRequired(e => e.Menager);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Expenses)
                .WithOptional(et => (Employee)et.ExpenseTarget);

            modelBuilder.Entity<OrderType>()
                 .HasMany(o => o.Orders)
                 .WithRequired(o => o.OrderType);
            modelBuilder.Entity<OrderType>()
                .HasMany(o => o.Specializations)
                .WithMany(s => s.OrderTypes);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Specializations)
                .WithMany(s => s.Companies);
            modelBuilder.Entity<Company>()
                .HasMany(c => c.CyclicOrders)
                .WithRequired(c => c.Company);

            //   modelBuilder.Entity<Expense>()
            //       .HasRequired(e => e.ExpenseTarget)
            // .WithMany(et => et.Expenses);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Expenses)
                .WithOptional(et => (Order)et.ExpenseTarget);

            modelBuilder.Entity<CyclicOrder>()
                .HasMany(e => e.Expenses)
                .WithOptional(et => (CyclicOrder)et.ExpenseTarget);



        }

    }
}