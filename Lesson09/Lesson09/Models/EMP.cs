namespace Lesson09.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMP")]
    public partial class EMP
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal EMPNO { get; set; }

        [StringLength(10)]
        public string ENAME { get; set; }

        [StringLength(9)]
        public string JOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MGR { get; set; }

        public DateTime? HIREDATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? COMM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DEPTNO { get; set; }

        [Column(TypeName = "numeric")]
        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
    }
}
