using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionaFacil.Model
{
    public class Calificacion_Parking
    {
        public long Cal_Id { get; set; }

        public long Usu_Id { get; set; }

        public long Park_Id { get; set; }

        public int Cal_Calificacion { get; set; }
    }
}