namespace EstacionaFacil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Opinion_Parking
    {
        [Key]
        public long Opi_Id { get; set; }

        public long? Usu_Id { get; set; }

        public long? Par_Id { get; set; }

        [StringLength(100)]
        public string Opi_Opinion { get; set; }

        public virtual Parking Parking { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
