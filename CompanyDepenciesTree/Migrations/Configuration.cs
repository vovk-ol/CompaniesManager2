namespace CompanyDepenciesTree.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CompanyDepenciesTree.Models.TreeViewModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompanyDepenciesTree.Models.TreeViewModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.CompaniesTreeViewTable.AddOrUpdate(
              p => p.Name,
              new CompanyEntity { Name = "Microsoft", Earning = 1000, ParentId = 0 },
              new CompanyEntity { Name = "Skype", Earning = 100, ParentId = 1 },
              new CompanyEntity { Name = "Nokia", Earning = 75, ParentId = 1 },
              new CompanyEntity { Name = "QT", Earning = 25, ParentId = 3 },
              new CompanyEntity { Name = "CP", Earning = 17, ParentId = 3 },
              new CompanyEntity { Name = "Google", Earning = 1000, ParentId = 0 },
              new CompanyEntity { Name = "AndroinDistributorCompany", Earning = 10, ParentId = 6 },
              new CompanyEntity { Name = "GoogleElectroCar", Earning = 35, ParentId = 6 },
              new CompanyEntity { Name = "Apple", Earning = 1000, ParentId = 0 }

            );

        }
    }
}
