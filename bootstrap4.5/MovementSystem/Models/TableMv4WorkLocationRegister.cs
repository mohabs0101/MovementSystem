using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("TableMV4_WORK_LOCATION_REGISTER")]
    public partial class TableMv4WorkLocationRegister
    {
        [Key]
        [Column("ID_WORK_LOCATION_REGISTER")]
        public int IdWorkLocationRegister { get; set; }
        [Column("ID_WORK_LOCATION")]
        public int? IdWorkLocation { get; set; }
        [Column("report_admin_location")]
        [StringLength(1000)]
        public string ReportAdminLocation { get; set; }
        [Column("date_add")]
        [StringLength(50)]
        public string DateAdd { get; set; }
    }
}
