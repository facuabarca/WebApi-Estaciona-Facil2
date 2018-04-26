namespace EstacionaFacil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Calificacion_Parking = new HashSet<Calificacion_Parking>();
            Opinion_Parking = new HashSet<Opinion_Parking>();
            Parking = new HashSet<Parking>();
            Reserva = new HashSet<Reserva>();
        }

        [Key]
        public long Usu_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Usu_Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Usu_Apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string Usu_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Usu_Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string Usu_Patente { get; set; }

        public long Usu_Tipo { get; set; }

        [StringLength(50)]
        public string Usu_Latitud { get; set; }

        [StringLength(50)]
        public string Usu_Longitud { get; set; }

        [StringLength(50)]
        public string Usu_Ciudad { get; set; }

        [Required]
        [StringLength(50)]
        public string Usu_Contrasena { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Calificacion_Parking> Calificacion_Parking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Opinion_Parking> Opinion_Parking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Parking> Parking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Reserva> Reserva { get; set; }

        public Tipo_Usuario Tipo_Usuario { get; set; }
    }
}
