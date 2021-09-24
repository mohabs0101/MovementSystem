using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("TableMV3_WORK_LOCATION")]
    public partial class TableMv3WorkLocation
    {
        [Key]
        [Column("ID_WORK_LOCATION")]
        public int IdWorkLocation { get; set; }
        [Column("location_category")]
        [StringLength(50)]
        public string LocationCategory { get; set; }
        [Column("work_location_name")]
        [StringLength(50)]
        public string WorkLocationName { get; set; }
        [Column("location_type")]
        [StringLength(50)]
        public string LocationType { get; set; }
        [Column("recentlit")]
        [StringLength(50)]
        public string Recentlit { get; set; }
        [Column("eliminate")]
        [StringLength(50)]
        public string Eliminate { get; set; }
        [Column("all_address")]
        [StringLength(200)]
        public string AllAddress { get; set; }
        [Column("geographical_location")]
        [StringLength(50)]
        public string GeographicalLocation { get; set; }
        [Column("aera_location")]
        [StringLength(50)]
        public string AeraLocation { get; set; }
        [Column("source_location")]
        [StringLength(50)]
        public string SourceLocation { get; set; }
        [Column("location_purpos")]
        [StringLength(50)]
        public string LocationPurpos { get; set; }
        [Column("work_location_admin")]
        [StringLength(50)]
        public string WorkLocationAdmin { get; set; }
        [Column("location_opening_date")]
        [StringLength(50)]
        public string LocationOpeningDate { get; set; }
        [Column("location_closing_date")]
        [StringLength(50)]
        public string LocationClosingDate { get; set; }
        [Column("notes_me")]
        [StringLength(1000)]
        public string NotesMe { get; set; }
        [Column("date_add")]
        [StringLength(50)]
        public string DateAdd { get; set; }
    }
}
