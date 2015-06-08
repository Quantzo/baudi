using System.Data.Entity;
using Baudi.DAL.Models;

namespace Baudi.DAL
{
    public class BaudiDbContext : DbContext
    {
        public BaudiDbContext()
            : base(
                "Server=(localdb)\\MSSQLLocalDB;Database=BaudiDB;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
            //Choose right initializer
            //Database.SetInitializer<BaudiDbContext>(new CreateDatabaseIfNotExists<BaudiDbContext>());
            //Database.SetInitializer<BaudiDbContext>(new DropCreateDatabaseAlways<BaudiDbContext>());
            //Database.SetInitializer<BaudiDbContext>(new DropCreateDatabaseIfModelChanges<BaudiDbContext>());

           // Database.SetInitializer(new BaudiDbInitializer());
            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Table names

            modelBuilder.Entity<OwningCompany>().ToTable("OwningCompanies");
            modelBuilder.Entity<Person>().ToTable("Peoples");
            modelBuilder.Entity<Building>().ToTable("Buildings");
            modelBuilder.Entity<Local>().ToTable("Locals");
            modelBuilder.Entity<Expense>().ToTable("Expenses");
            modelBuilder.Entity<Rent>().ToTable("Rents");
            modelBuilder.Entity<CyclicOrder>().ToTable("CyclicOrders");
            modelBuilder.Entity<Order>().ToTable("Orders");

            #region Employee entity maping 

            modelBuilder.Entity<Employee>()
                .ToTable("Employees")
                .Map<Administrator>(m => m.Requires("Type").HasValue("Administrator"))
                .Map<Menager>(m => m.Requires("Type").HasValue("Menager"))
                .Map<Dispatcher>(m => m.Requires("Type").HasValue("Dispatcher"));

            #endregion

            #endregion

            #region Mappings

            #region Buildings

            modelBuilder.Entity<Building>()
                .HasMany(b => b.Locals)
                .WithOptional(l => l.Building);
            modelBuilder.Entity<Building>()
                .HasMany(b => b.CyclicOrders)
                .WithRequired(c => c.Building);
            modelBuilder.Entity<Building>()
                .HasMany(b => b.Notifactions)
                .WithOptional(n => (Building) n.NotificationTarget);

            #endregion

            #region Notifications

            modelBuilder.Entity<Notification>()
                .HasMany(n => n.Orders)
                .WithRequired(o => o.Notification);

            #endregion

            #region Locals

            modelBuilder.Entity<Local>()
                .HasMany(l => l.Ownerships)
                .WithRequired(o => o.Local);
            modelBuilder.Entity<Local>()
                .HasMany(l => l.Notifactions)
                .WithOptional(n => (Local) n.NotificationTarget);

            #endregion

            #region Ownership

            modelBuilder.Entity<Ownership>()
                .HasMany(ow => ow.Rents)
                .WithRequired(r => r.Ownership);

            #endregion

            #region Owners

            #region Peoples

            modelBuilder.Entity<Person>()
                .HasMany(o => o.Ownerships)
                .WithOptional(o => (Person) o.Owner);
            modelBuilder.Entity<Person>()
                .HasMany(o => o.Notifications)
                .WithOptional(n => (Person) n.Owner);

            #endregion

            #region Owning Companies

            modelBuilder.Entity<OwningCompany>()
                .HasMany(o => o.Ownerships)
                .WithOptional(o => (OwningCompany) o.Owner);
            modelBuilder.Entity<OwningCompany>()
                .HasMany(o => o.Notifications)
                .WithOptional(n => (OwningCompany) n.Owner);

            #endregion

            #endregion

            #region Employees

            #region Dispatcher

            modelBuilder.Entity<Dispatcher>()
                .HasMany(d => d.Notifications)
                .WithRequired(n => n.Dispatcher);

            #endregion

            #region Menager

            modelBuilder.Entity<Menager>()
                .HasMany(m => m.Orders)
                .WithRequired(o => o.Menager);
            modelBuilder.Entity<Menager>()
                .HasMany(m => m.CyclicOrders)
                .WithRequired(c => c.Menager);
            modelBuilder.Entity<Menager>()
                .HasMany(m => m.MenagerExpenses)
                .WithRequired(e => e.Menager);

            #endregion

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Expenses)
                .WithOptional(et => (Employee) et.ExpenseTarget);

            #endregion

            #region Order Types

            modelBuilder.Entity<OrderType>()
                .HasMany(o => o.Orders)
                .WithRequired(o => o.OrderType);
            modelBuilder.Entity<OrderType>()
                .HasMany(o => o.Specializations)
                .WithMany(s => s.OrderTypes);

            #endregion

            #region Companies

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Specializations)
                .WithMany(s => s.Companies);
            modelBuilder.Entity<Company>()
                .HasMany(c => c.CyclicOrders)
                .WithRequired(c => c.Company);

            #endregion

            #region Orders

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Expenses)
                .WithOptional(et => (Order) et.ExpenseTarget);
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Notification)
                .WithMany(n => n.Orders);

            #endregion

            #region Cyclic Orders

            modelBuilder.Entity<CyclicOrder>()
                .HasMany(e => e.Expenses)
                .WithOptional(et => (CyclicOrder) et.ExpenseTarget);

            #endregion

            #endregion
        }

        #region DbSets

        #region Notification Targets

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Local> Locals { get; set; }

        #endregion

        #region Money related things

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Rent> Rents { get; set; }

        #endregion

        #region Expenses Target

        public DbSet<CyclicOrder> CyclicOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        #endregion

        #region Owners

        public DbSet<OwningCompany> OwningCompanies { get; set; }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }

        #endregion

        #region Companies

        public DbSet<Company> Companies { get; set; }

        #endregion

        #endregion
    }
}