namespace EstacionaFacil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parking")]
    public partial class Parking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parking()
        {
            //Calificacion_Parking = new HashSet<Calificacion_Parking>();
            Estacionamiento_Parking = new HashSet<Estacionamiento_Parking>();
            Opinion_Parking = new HashSet<Opinion_Parking>();
            Reserva = new HashSet<Reserva>();
        }

        [Key]
        public long Par_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Par_Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Par_Longitud { get; set; }

        [Required]
        [StringLength(50)]
        public string Par_Latitud { get; set; }

        [Required]
        [StringLength(50)]
        public string Par_Calle { get; set; }

        public int Par_Altura { get; set; }

        [Required]
        [StringLength(50)]
        public string Par_Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string Par_Horario { get; set; }

        public long Usu_Id { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public List<Calificacion_Parking> Calificacion_Parking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Estacionamiento_Parking> Estacionamiento_Parking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Opinion_Parking> Opinion_Parking { get; set; }

        public Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Reserva> Reserva { get; set; }
    }
}
