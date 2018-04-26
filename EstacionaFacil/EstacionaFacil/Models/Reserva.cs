namespace EstacionaFacil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reserva")]
    public partial class Reserva
    {
        [Key]
        public long Res_Id { get; set; }

        public long? Park_Id { get; set; }

        public long? Usu_Id { get; set; }

        public bool? Res_Estado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Res_Dia { get; set; }

        [StringLength(50)]
        public string Res_Entrada { get; set; }

        [StringLength(50)]
        public string Res_Salida { get; set; }

        public virtual Parking Parking { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
