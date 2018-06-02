using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using EntityFrameworkModels;

namespace HttpTriggeredAzureFunction
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public short Edad { get; set; }
        public string Ciudad { get; set; }
    }

    public static class HttpTriggerCS_RegCliente
    {
        [FunctionName("HttpTriggerCS_RegCliente")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(authLevel: AuthorizationLevel.Function, methods: "post", Route = null)]HttpRequestMessage req,
                TraceWriter log)
        {
            log.Info("Iniciando registro de cliente");
            Cliente ClienteRecibido = await req.Content.ReadAsAsync<Cliente>();
            EntityFrameworkModels.Repositories.ClientesDBContext context =
                new EntityFrameworkModels.Repositories.ClientesDBContext("metadata=res://*/ClientEFModels.csdl|res://*/ClientEFModels.ssdl|res://*/ClientEFModels.msl;provider=System.Data.SqlClient;provider connection string='data source=tcp:garonetdatabaseserver.database.windows.net,1433;initial catalog=AzureFunctionsTestBD;user id=estebangaro;password=}$G4r0n3725240912}]#};MultipleActiveResultSets=True;App=EntityFramework'");
            HttpResponseMessage Response;

            try
            {
                context.RegistraCliente(new EntityFrameworkModels.Cliente
                {
                    Ciudad = ClienteRecibido.Ciudad,
                    Edad = ClienteRecibido.Edad,
                    Id = ClienteRecibido.Id,
                    Nombre = ClienteRecibido.Nombre
                });
                Response = req.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = $"El cliente {ClienteRecibido.Nombre}, se ha registrado exitosamente"
                });
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error al registrar al cliente: {ex.Message}");
                Response = req.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            finally
            {
                log.Info("Finalizando registro de cliente");
            }

            return Response;
        }
    }
}
