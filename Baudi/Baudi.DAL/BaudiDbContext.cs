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

            modelBuilder.Entity<Notification>().ToTable("Notifications");
            modelBuilder.Entity<Ownership>().ToTable("Ownerships");
            modelBuilder.Entity<OrderType>().ToTable("OrderTypes");
            modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<Specialization>().ToTable("Specializations");

            #region Employee entity maping 

            modelBuilder.Entity<Employee>()
                .ToTable("Employees")
                .Map<Administrator>(m => m.Requires("Type").HasValue("Administrator"))
                .Map<Menager>(m => m.Requires("Type").HasValue("Menager"))
                .Map<Dispatcher>(m => m.Requires("Type").HasValue("Dispatcher"));

            #endregion

            #region Payment entity mapping

            modelBuilder.Entity<Payment>()
                .ToTable("Payments")
                .Map<Salary>(m => m.Requires("Type").HasValue("Salary"))
                .Map<Expense>(m => m.Requires("Type").HasValue("Expense"))
                .Map<Rent>(m => m.Requires("Type").HasValue("Rent"));

            #endregion

            #region ExpenseTarget entity maping

            modelBuilder.Entity<ExpenseTarget>()
                .ToTable("ExpenseTargets")
                .Map<CyclicOrder>(m => m.Requires("Type").HasValue("CyclicOrder"))
                .Map<Order>(m => m.Requires("Type").HasValue("Order"));

            #endregion

            #region NotificationTarget entity maping

            modelBuilder.Entity<NotificationTarget>()
                .ToTable("NotificationTargets")
                .Map<Building>(m => m.Requires("Type").HasValue("Building"))
                .Map<Local>(m => m.Requires("Type").HasValue("Local"));

            #endregion

            #region Owner entity maping

            modelBuilder.Entity<Owner>()
                .ToTable("Owners")
                .Map<OwningCompany>(m => m.Requires("Type").HasValue("Company"))
                .Map<Person>(m => m.Requires("Type").HasValue("Person"));

            #endregion

            #endregion

            #region Mappings

            #region NotficationTargets

            modelBuilder.Entity<NotificationTarget>()
                .HasMany(nt => nt.Notifactions)
                .WithOptional(n => n.NotificationTarget);



            #region Buildings

            modelBuilder.Entity<Building>()
                .HasMany(b => b.Locals)
                .WithRequired(l => l.Building);


            modelBuilder.Entity<Building>()
                .HasMany(b => b.CyclicOrders)
                .WithRequired(c => c.Building)
                .WillCascadeOnDelete(true);


            #endregion

            #region Locals

            modelBuilder.Entity<Local>()
                .HasMany(l => l.Ownerships)
                .WithOptional(o => o.Local);



            #endregion

            #endregion

            #region Owners

            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Ownerships)
                .WithOptional(ow => ow.Owner);


            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Notifications)
                .WithRequired(n => n.Owner)
                .WillCascadeOnDelete(true);

            #endregion

            #region ExpenseTargets

            modelBuilder.Entity<ExpenseTarget>()
                .HasMany(e => e.Expenses)
                .WithRequired(et => et.ExpenseTarget)
                .WillCascadeOnDelete(true);

            #endregion

            #region Notifications

            modelBuilder.Entity<Notification>()
                .HasMany(n => n.Orders)
                .WithRequired(o => o.Notification)
                .WillCascadeOnDelete(true);

            #endregion

            #region Ownership

            modelBuilder.Entity<Ownership>()
                .HasMany(ow => ow.Rents)
                .WithRequired(r => r.Ownership)
                .WillCascadeOnDelete(true);

            #endregion

            #region Employees

            #region Dispatcher

            modelBuilder.Entity<Dispatcher>()
                .HasMany(d => d.Notifications)
                .WithOptional(n => n.Dispatcher);

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
            modelBuilder.Entity<Menager>()
                .HasMany(m => m.MenagerSalaries)
                .WithOptional(s => s.Menager)
                .WillCascadeOnDelete(false);

            #endregion

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Salaries)
                .WithRequired(s => s.Employee)
                .WillCascadeOnDelete(true);

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

            #endregion
        }

        #region DbSets

        #region Notification Targets

        public DbSet<NotificationTarget> NotificationTargets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Local> Locals { get; set; }

        #endregion

        #region Money related things

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Salary> Salaries { get; set; }

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