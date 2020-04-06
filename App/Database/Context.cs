using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace App.Database
{
    public class Context : DbContext
    {
        public static string ConnectionString => new FbConnectionStringBuilder()
        {
            DataSource = "localhost",
            Database = $@"{System.IO.Directory.GetCurrentDirectory()}\database.fdb",
            UserID = "sysdba",
            Password = "masterkey",
            ServerType = FbServerType.Default
        }.ToString();

        public DbSet<Staff> Staffs { get; set; }

        public Context(string connectionString)
            : base(new FbConnection(connectionString), true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var staffConf = modelBuilder.Entity<Staff>();

            staffConf
                .HasOptional(staff => staff.Manager)
                .WithMany()
                .Map(fkamc => fkamc.MapKey("ManagerId"));
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker
                .Entries<ITimeStamped>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTime.Now;
                }
                entity.Entity.UpdatedAt = DateTime.Now;
            }
        }
    }
}
