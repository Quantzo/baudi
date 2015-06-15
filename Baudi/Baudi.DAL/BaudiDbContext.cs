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

            Database.SetInitializer(new BaudiDbInitializer());
            //Database.Initialize(true);
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
                .WithRequired(l => l.Building)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Building>()
                .HasMany(b => b.CyclicOrders)
                .WithRequired(c => c.Building)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Building>()
                .HasMany(b => b.Notifactions)
                .WithOptional(n => (Building) n.NotificationTarget)
                .WillCascadeOnDelete(true); 

            #endregion

            #region Notifications

            modelBuilder.Entity<Notification>()
                .HasMany(n => n.Orders)
                .WithRequired(o => o.Notification)
                .WillCascadeOnDelete(true);

            #endregion

            #region Locals

            modelBuilder.Entity<Local>()
                .HasMany(l => l.Ownerships)
                .WithRequired(o => o.Local)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<Local>()
                .HasMany(l => l.Notifactions)
                .WithOptional(n => (Local) n.NotificationTarget);
                

                

            #endregion

            #region Ownership

            modelBuilder.Entity<Ownership>()
                .HasMany(ow => ow.Rents)
                .WithOptional(r => r.Ownership)
                .WillCascadeOnDelete(true);

            #endregion

            #region Owners

            #region Peoples

            modelBuilder.Entity<Person>()
                .HasMany(o => o.Ownerships)
                .WithOptional(o => (Person) o.Owner)
                                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Person>()
                .HasMany(o => o.Notifications)
                .WithOptional(n => (Person) n.Owner)
                                .WillCascadeOnDelete(true);

            #endregion

            #region Owning Companies

            modelBuilder.Entity<OwningCompany>()
                .HasMany(o => o.Ownerships)
                .WithOptional(o => (OwningCompany) o.Owner)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<OwningCompany>()
                .HasMany(o => o.Notifications)
                .WithOptional(n => (OwningCompany) n.Owner)
                .WillCascadeOnDelete(true);

            #endregion

            #endregion

            #region Employees

            #region Dispatcher

            modelBuilder.Entity<Dispatcher>()
                .HasMany(d => d.Notifications)
                .WithOptional(n => n.Dispatcher)
                .WillCascadeOnDelete(false);

            #endregion

            #region Menager

            modelBuilder.Entity<Menager>()
                .HasMany(m => m.Orders)
                .WithOptional(o => o.Menager)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Menager>()
                .HasMany(m => m.CyclicOrders)
                .WithOptional(c => c.Menager)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Menager>()
                .HasMany(m => m.MenagerExpenses)
                .WithOptional(e => e.Menager)
                .WillCascadeOnDelete(false);

            #endregion

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Expenses)
                .WithOptional(et => (Employee) et.ExpenseTarget).WillCascadeOnDelete(true);


            #endregion

            #region Order Types

            modelBuilder.Entity<OrderType>()
                .HasMany(o => o.Orders)
                .WithOptional(o => o.OrderType);
            modelBuilder.Entity<OrderType>()
                .HasMany(o => o.Specializations)
                .WithMany(s => s.OrderTypes)
                .Map(os =>
                {
                    os.MapRightKey("SpezializationRefId");
                    os.MapLeftKey("OrderTypeRefId");
                    os.ToTable("SpecializationOrderType");
                }
                );

            #endregion

            #region Companies

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Specializations)
                .WithMany(s => s.Companies)
                .Map(sc =>
                {
                    sc.MapRightKey("SpezializationRefId");
                    sc.MapLeftKey("CompanyfId");
                    sc.ToTable("SpecializationCompany");
                }
                );

            modelBuilder.Entity<Company>()
                .HasMany(c => c.CyclicOrders)
                .WithOptional(c => c.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Orders)
                .WithOptional(o => o.Company)
                .WillCascadeOnDelete(false);

            #endregion

            #region Orders

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Expenses)
                .WithOptional(et => (Order)et.ExpenseTarget)
                .WillCascadeOnDelete(true);
                

            #endregion

            #region Cyclic Orders

            modelBuilder.Entity<CyclicOrder>()
                .HasMany(c => c.Expenses)
                .WithOptional(e => (CyclicOrder) e.ExpenseTarget);


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