using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_EnMetodosHttp.Models;

namespace WebApi_EnNomAcciones.Controllers
{
    public class ColorBase: ApiController
    {
        public virtual async Task<IHttpActionResult> GetPorId(int identifer)
        {
            WebApi_EnMetodosHttp.Models.ColorsActionsLogic Logic =
                new ColorsActionsLogic();
            Color color = await Logic.GetColorById(identifer);

            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }
        
        public virtual async Task<IHttpActionResult> SaveColor(Color color)
        {
            WebApi_EnMetodosHttp.Models.ColorsActionsLogic Logic =
                new ColorsActionsLogic();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            color = await Logic.PostColor(color);

            return CreatedAtRoute("DefaultApi", new { id = color.Id }, color);
        }
        
        public virtual async Task<IHttpActionResult>
            Actualizar(int id, Color color)
        {
            WebApi_EnMetodosHttp.Models.ColorsActionsLogic Logic =
                new ColorsActionsLogic();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != color.Id)
            {
                return BadRequest();
            }

            try
            {
                await Logic.UpdateColor(color);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await Logic.ColorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public virtual async Task<IHttpActionResult> Eliminar(int identifer)
        {
            WebApi_EnMetodosHttp.Models.ColorsActionsLogic Logic =
                new ColorsActionsLogic();

            Color color = await Logic.DeleteColor(identifer);

            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }
    }
}