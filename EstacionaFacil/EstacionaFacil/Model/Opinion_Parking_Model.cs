using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionaFacil.Model
{
    public class Opinion_Parking_Model
    {
        public long Opi_Id { get; set; }

        public long? Usu_Id { get; set; }

        public long? Par_Id { get; set; }

        public string Opi_Opinion { get; set; }
    }
}