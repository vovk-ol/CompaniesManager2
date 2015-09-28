namespace CompanyDepenciesTree.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompaniesTreeViewTable")]
    public partial class CompanyEntity
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Earning { get; set; }

        public int? ParentId { get; set; }
    }
}
