namespace CompanyDepenciesTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompaniesTreeViewTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, fixedLength: true),
                        Earning = c.Int(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompaniesTreeViewTable");
        }
    }
}
