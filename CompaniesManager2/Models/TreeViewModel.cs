namespace CompaniesManager2.Models
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

        public virtual DbSet<CompaniesTreeViewTable> CompaniesTreeViewTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompaniesTreeViewTable>()
                .Property(e => e.Name)
                .IsFixedLength();
        }
    }
}
