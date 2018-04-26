namespace EstacionaFacil.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EstacionaFacilModel : DbContext
    {
        public EstacionaFacilModel()
            : base("name=Model")
        {
        }

        public virtual DbSet<Calificacion_Parking> Calificacion_Parking { get; set; }
        public virtual DbSet<Estacionamiento_Parking> Estacionamiento_Parking { get; set; }
        public virtual DbSet<Opinion_Parking> Opinion_Parking { get; set; }
        public virtual DbSet<Parking> Parking { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parking>()
                .HasMany(e => e.Calificacion_Parking)
                .WithOptional(e => e.Parking)
                .HasForeignKey(e => e.Park_Id);

            modelBuilder.Entity<Parking>()
                .HasMany(e => e.Estacionamiento_Parking)
                .WithRequired(e => e.Parking)
                .HasForeignKey(e => e.Park_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parking>()
                .HasMany(e => e.Reserva)
                .WithOptional(e => e.Parking)
                .HasForeignKey(e => e.Park_Id);

            modelBuilder.Entity<Tipo_Usuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Tipo_Usuario)
                .HasForeignKey(e => e.Usu_Tipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Parking)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
