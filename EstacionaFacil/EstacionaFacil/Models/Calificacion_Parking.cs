namespace EstacionaFacil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Calificacion_Parking
    {
        [Key]
        public long Cal_Id { get; set; }

        public long? Usu_Id { get; set; }

        public long? Park_Id { get; set; }

        public int? Cal_Calificacion { get; set; }

        public virtual Parking Parking { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
