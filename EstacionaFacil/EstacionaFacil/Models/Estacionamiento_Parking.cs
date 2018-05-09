namespace EstacionaFacil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Estacionamiento_Parking
    {
        [Key]
        public long Est_Id { get; set; }

        public long Park_Id { get; set; }

        public int Est_Cantidad { get; set; }

        public int Est_Ocupado { get; set; }

        public int Est_Disponible { get; set; }

        public bool Est_Estado { get; set; }

        public Parking Parking { get; set; }
    }
}
