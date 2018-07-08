using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace FunctionApp_QueueTriggered
{
    public static class Function1
    {
        [FunctionName("Function1")]
        [return: Table("EquiposMX", Connection = "QueueStorage")]
        public static Models.EquipoMX Run([QueueTrigger("queue-equipos", Connection = "QueueStorage")]
            string equipoMensaje, TraceWriter log)
        {
            GaroData.Entities.Equipo Equipo = JsonConvert
                        .DeserializeObject<GaroData.Entities.Equipo>(equipoMensaje);
            try
            {
                using (Models.EquiposManager EquiposDb = 
                    new Models.EquiposManager(GetEnvironmentVariable("EquiposModeloEF")))
                {
                    EquiposDb.RegistrarEquipo(Equipo);
                }
                log.Info($"Se ha registrado correctamente el equipo {Equipo.IdEquipo}");
            }
            catch (Exception ex)
            {
                log.Info($"Ha falado el registro del equipo; Error {ex.Message}");
            }

            return new Models.EquipoMX
            {
                Fundacion = Equipo.Fundacion,
                IdEquipo = Equipo.IdEquipo,
                Nombre = Equipo.Nombre,
                Presidente = Equipo.Presidente,
                Titulos = Equipo.Titulos,
                PartitionKey = "LigaMX",
                RowKey = string.Concat(Equipo.IdEquipo, "-", Equipo.Nombre)
            };
        }

        public static string GetEnvironmentVariable(string name)
        {
            return
                System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
