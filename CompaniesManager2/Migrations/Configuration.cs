namespace CompaniesManager2.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CompaniesManager2.Models.TreeViewModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompaniesManager2.Models.TreeViewModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.CompaniesTreeViewTable.AddOrUpdate(
                  p => p.Name,
                  new CompaniesTreeViewTable { Name = "Microsoft", AnnualEarning = 1000, ParentId=0 },
                  new CompaniesTreeViewTable { Name = "Skype", AnnualEarning = 100, ParentId = 1 },
                  new CompaniesTreeViewTable { Name = "Nokia", AnnualEarning = 75, ParentId = 1 },
                  new CompaniesTreeViewTable { Name = "QT", AnnualEarning = 25, ParentId = 3 },
                  new CompaniesTreeViewTable { Name = "CP", AnnualEarning = 17, ParentId = 3 },
                  new CompaniesTreeViewTable { Name = "Google", AnnualEarning = 1000, ParentId = 0 },
                  new CompaniesTreeViewTable { Name = "Apple", AnnualEarning = 1000, ParentId = 0 }

                );
            
        }
    }
}
