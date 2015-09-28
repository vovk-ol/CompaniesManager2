namespace CompanyDepenciesTree.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TreeViewModel : DbContext
    {
        public TreeViewModel()
            : base("name=TreeViewModel")
        {
        }

        public virtual DbSet<CompanyEntity> CompaniesTreeViewTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
