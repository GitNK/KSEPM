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
        public DbSet<UserCallback> UserCallbacks { get; set; }
    }

    public class KSEPMDbInitializer<T> : CreateDatabaseIfNotExists<KSEPMDbContext>
    {
        protected override void Seed(KSEPMDbContext context)
        {
            IdentityDbInitializer.InitializeDb();
            ChairDbInitializer.Initialize(context);
            //var Chair

            base.Seed(context);
        }
    }
}
