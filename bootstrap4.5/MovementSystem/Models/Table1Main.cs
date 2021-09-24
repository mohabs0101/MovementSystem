using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovementSystem.Models
{
    [Table("Table1_MAIN")]
    public partial class Table1Main
    {
        [Key]
        [Column("ID_MAIN")]
        public int IdMain { get; set; }
        [Column("activation")]
        [StringLength(50)]
        public string Activation { get; set; }
        [Column("no_statistical")]
        [StringLength(50)]
        public string NoStatistical { get; set; }
        [Column("no_broadium")]
        [StringLength(50)]
        public string NoBroadium { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("second_name")]
        [StringLength(50)]
        public string SecondName { get; set; }
        [Column("third_name")]
        [StringLength(50)]
        public string ThirdName { get; set; }
        [Column("forurth_name")]
        [StringLength(50)]
        public string ForurthName { get; set; }
        [Column("clan_name")]
        [StringLength(50)]
        public string ClanName { get; set; }
        [Column("full_name")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Column("first_name_mother")]
        [StringLength(50)]
        public string FirstNameMother { get; set; }
        [Column("second_name_mother")]
        [StringLength(50)]
        public string SecondNameMother { get; set; }
        [Column("third_name_mother")]
        [StringLength(50)]
        public string ThirdNameMother { get; set; }
        [Column("clan_name_mother")]
        [StringLength(50)]
        public string ClanNameMother { get; set; }
        [Column("full_mother_name")]
        [StringLength(50)]
        public string FullMotherName { get; set; }
        [Column("picture_emplooy", TypeName = "image")]
        public byte[] PictureEmplooy { get; set; }
        [Column("TOTAL_path_from_t22")]
        [StringLength(1000)]
        public string TotalPathFromT22 { get; set; }
        [Column("name_job_position")]
        [StringLength(50)]
        public string NameJobPosition { get; set; }
        [Column("code_from_t22")]
        [StringLength(1000)]
        public string CodeFromT22 { get; set; }
        [Column("work_location_t1")]
        [StringLength(50)]
        public string WorkLocationT1 { get; set; }
        [Column("type_publication_procedure_t1")]
        [StringLength(50)]
        public string TypePublicationProcedureT1 { get; set; }
        [Column("item_t1")]
        [StringLength(50)]
        public string ItemT1 { get; set; }
        [Column("job_address_t1")]
        [StringLength(50)]
        public string JobAddressT1 { get; set; }
        [Column("the_work_t1")]
        [StringLength(3000)]
        public string TheWorkT1 { get; set; }
        [Column("job_description_t1")]
        [StringLength(1000)]
        public string JobDescriptionT1 { get; set; }
        [Column("labor_type_t1")]
        [StringLength(50)]
        public string LaborTypeT1 { get; set; }
        [Column("labor_replacements_t1")]
        [StringLength(50)]
        public string LaborReplacementsT1 { get; set; }
    }
}
