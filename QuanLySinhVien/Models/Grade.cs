namespace QuanLySinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grade
    {
        public int GradeID { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentID { get; set; }

        public int ClassID { get; set; }

        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        public int Score { get; set; }

        public virtual Class Class { get; set; }

        public virtual Student Student { get; set; }
    }
}
