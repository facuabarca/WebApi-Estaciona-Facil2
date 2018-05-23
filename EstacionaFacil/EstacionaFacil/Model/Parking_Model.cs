using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionaFacil.Model
{
    public class Parking_Model
    {
        public long Par_Id { get; set; }
        public string Par_Nombre { get; set; }
        public string Par_Longitud { get; set; }
        public string Par_Latitud { get; set; }
        public string Par_Calle { get; set; }
        public int Par_Altura { get; set; }
        public string Par_Telefono { get; set; }
        public string Par_Horario { get; set; }
        public long Usu_Id { get; set; }

        public List<Calificacion_Parking_Model> Calificacion_Parking { get; set; }
    }
}