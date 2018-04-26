using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EstacionaFacil.Controllers
{
    public class UsuarioPruebaController : ApiController
    {
        public string Post([FromBody] postModelData obj)
        {
            string myObj = "Success";
            return myObj.ToString();

            
        }

    }
    public class postModelData
    {
        public string FstVarValue;
        public string SndVarValue;
    }
}
