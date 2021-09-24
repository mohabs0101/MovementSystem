using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("Root1_RECENTLIT")]
    public partial class Root1Recentlit
    {
        [Key]
        [Column("ID_RECENTLIT")]
        public int IdRecentlit { get; set; }
        [Column("recentlit_name")]
        [StringLength(50)]
        public string RecentlitName { get; set; }
    }
}
