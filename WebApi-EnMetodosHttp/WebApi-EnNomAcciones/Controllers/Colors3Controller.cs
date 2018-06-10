using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_EnMetodosHttp.Models;

namespace WebApi_EnNomAcciones.Controllers
{
    [RoutePrefix("webapi/colors")]
    public class Colors3Controller : ColorBase
    {
        // http://localhost/webapi/colors/ConsultaPorId/{identifer}
        [Route("ConsultaPorId/{identifer:int}")]
        [HttpGet]
        [ResponseType(typeof(Color))]
        public async Task<IHttpActionResult> ConsultaPorId(int identifer)
        {
            var response = await GetPorId(identifer);
            return response;
        }

        // http://localhost/webapi/colors/Guardar, ruta con posibilidad de conflicto, pues 
        // la coincide con la plantilla de enrutamiento por nombre de acciones: {action}/{controller}/{identifer}
        [Route("Guardar")]
        [ActionName("Guardar")]
        public async Task<IHttpActionResult> PostColor(Color color)
        {
            var response = await SaveColor(color);
            return response;
        }

        // http://localhost/webapi/colors/Actualizar/{id}
        [Route("Actualizar/{id:int}")]
        [HttpPut]
        public override async Task<IHttpActionResult>
            Actualizar(int id, Color color)
        {
            var response = await base.Actualizar(id, color);
            return response;
        }

        // http://localhost/webapi/colors/Eliminar/{identifer}
        [Route("Eliminar/{indentifer:int}")]
        [HttpDelete]
        public override async Task<IHttpActionResult> Eliminar(int identifer)
        {
            var response = await base.Eliminar(identifer);
            return response;
        }

        // http://localhost/api/{identifer}
        public async Task<IHttpActionResult> DeleteColor(int identifer)
        {
            var response = await base.Eliminar(identifer);
            return response;
        }

        // http://localhost/EliminarColor/Colors3/{id:int}
        [HttpDelete]
        public async Task<IHttpActionResult> EliminarColor(int id)
        {
            var response = await base.Eliminar(id);
            return response;
        }
    }
}
