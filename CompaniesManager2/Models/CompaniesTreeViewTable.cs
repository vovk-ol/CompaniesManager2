namespace CompaniesManager2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompaniesTreeViewTable")]
    public partial class CompaniesTreeViewTable
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? AnnualEarning { get; set; }

        public int? ParentId { get; set; }
    }
}
