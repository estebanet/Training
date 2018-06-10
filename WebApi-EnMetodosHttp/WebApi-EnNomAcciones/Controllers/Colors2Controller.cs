using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_EnMetodosHttp.Models;

namespace WebApi_EnNomAcciones.Controllers
{
    public class Colors2Controller : ColorBase
    {
        // GetPorId/Colors2/4 HTTP 1.1 GET
        //[HttpGet], Convención de nombres de métodos HTTP (para definir TIPO de operación)
        [ResponseType(typeof(Color))]
        public override async Task<IHttpActionResult> GetPorId(int identifer)
        {
            var response = await base.GetPorId(identifer);
            return response;
        }

        // Guardar/Colors2 HTTP 1.1 *POST
        [ActionName("Guardar")]
        [HttpPost]
        public override async Task<IHttpActionResult> SaveColor(Color color)
        {
            var response = await base.SaveColor(color);
            return response;
        }

        // Actualizar/Colors2?id={id}
        [HttpPut]
        public override async Task<IHttpActionResult>
            Actualizar(int id, Color color)
        {
            var response = await base.Actualizar(id, color);
            return response;
        }

        // Eliminar/Colors2/2
        [HttpDelete]
        public override async Task<IHttpActionResult> Eliminar(int identifer)
        {
            var response = await base.Eliminar(identifer);
            return response;
        }
    }
}
