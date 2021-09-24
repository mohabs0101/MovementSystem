using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("Root8_ELIMINATE")]
    public partial class Root8Eliminate
    {
        [Key]
        [Column("ID_ELIMINATE")]
        public int IdEliminate { get; set; }
        [Column("eliminate_name")]
        [StringLength(50)]
        public string EliminateName { get; set; }
    }
}
