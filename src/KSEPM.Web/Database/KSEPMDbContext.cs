using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using KSEPM.Web.Database.Entities;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.Infrastructure.Attributes;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KSEPM.Web.Database
{
    public class KSEPMDbContext : IdentityDbContext<ApplicationUser>
    {
        public KSEPMDbContext()
            : base("KSEPMDbContext")
        {
        }

        static KSEPMDbContext()
        {
            System.Data.Entity.Database.SetInitializer<KSEPMDbContext>(new KSEPMDbInitializer<KSEPMDbContext>());
        }

        public static KSEPMDbContext Create()
        {
            return new KSEPMDbContext();
        }

        public DbSet<Sell> Sells { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<ChairLine> ChairLines { get; set; }
        public DbSet<ChairOption> ChairOptions { get; set; }
        public DbSet<SellPoint> SellPoints { get; set; }
    }

    public class KSEPMDbInitializer<T> : CreateDatabaseIfNotExists<KSEPMDbContext>
    {
        public override void InitializeDatabase(KSEPMDbContext context)
        {
            //  context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
            //   , string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(KSEPMDbContext context)
        {
            IdentityDbInitializer.InitializeDb();
            ChairDbInitializer.Initialize(context);
            //var Chair

            base.Seed(context);
        }
    }
}
