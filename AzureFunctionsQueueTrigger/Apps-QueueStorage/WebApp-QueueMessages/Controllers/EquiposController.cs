using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_QueueMessages.Controllers
{
    public class EquiposController : Controller
    {
        // GET: Equipos
        public ActionResult Index()
        {
            IEnumerable<GaroData.Entities.Equipo> Equipos;

            try
            {
                using (GaroData.EquiposModeloEF DbContext = new GaroData.EquiposModeloEF())
                { 
                    Equipos = DbContext.Equipos.ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Ha fallado la consulta de equipos; " +
                    $"Error {ex.Message}");
                Equipos = new List<GaroData.Entities.Equipo>();
            }

            return View(Equipos);
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult>
            Registrar(GaroData.Entities.Equipo equipo)
        {
            JsonResult RespuestaRegistro;
            try
            {
                Models.QueueStorageManager QueuesManager = new Models.QueueStorageManager();
                await QueuesManager.RegisterMessage(JsonConvert.SerializeObject(equipo),
                    ConfigurationManager.AppSettings["QueueEquipos"]);
                RespuestaRegistro = Json(new { Estado = true });
            }
            catch (Exception ex)
            {
                RespuestaRegistro = Json(new { Estado = false, Message = ex.Message });
            }

            return RespuestaRegistro;
        }
    }
}