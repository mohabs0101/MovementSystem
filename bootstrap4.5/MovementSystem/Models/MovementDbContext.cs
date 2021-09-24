using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MovementSystem.Models
{
    public partial class MovementDbContext : DbContext
    {
        public MovementDbContext()
        {
        }

        public MovementDbContext(DbContextOptions<MovementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Root1Recentlit> Root1Recentlits { get; set; }
        public virtual DbSet<Root8Eliminate> Root8Eliminates { get; set; }
        public virtual DbSet<RootMv1VehicleBodyType> RootMv1VehicleBodyTypes { get; set; }
        public virtual DbSet<RootMv2VehicleName> RootMv2VehicleNames { get; set; }
        public virtual DbSet<RootMv3VehicleWarehouse> RootMv3VehicleWarehouses { get; set; }
        public virtual DbSet<RootMv4VehicleSource> RootMv4VehicleSources { get; set; }
        public virtual DbSet<Table1Main> Table1Mains { get; set; }
        public virtual DbSet<TableMv1Vehicle> TableMv1Vehicles { get; set; }
        public virtual DbSet<TableMv2StatusVehicleRegister> TableMv2StatusVehicleRegisters { get; set; }
        public virtual DbSet<TableMv3WorkLocation> TableMv3WorkLocations { get; set; }
        public virtual DbSet<TableMv4WorkLocationRegister> TableMv4WorkLocationRegisters { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QVESL2U\\MOH_INS1;Initial Catalog=DB_SMART_MANAGMANT;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Root1Recentlit>(entity =>
            {
                entity.HasKey(e => e.IdRecentlit)
                    .HasName("PK_Root1_RECETLIT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
