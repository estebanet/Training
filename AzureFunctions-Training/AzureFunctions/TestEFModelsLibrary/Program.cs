using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFModelsLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityFrameworkModels.Repositories.ClientesDBContext context =
                new EntityFrameworkModels.Repositories.ClientesDBContext("metadata=res://*/ClientEFModels.csdl|res://*/ClientEFModels.ssdl|res://*/ClientEFModels.msl;provider=System.Data.SqlClient;provider connection string='data source=tcp:garonetdatabaseserver.database.windows.net,1433;initial catalog=AzureFunctionsTestBD;user id=estebangaro;password=}$G4r0n3725240912}]#};MultipleActiveResultSets=True;App=EntityFramework'");

            try
            {
                context.RegistraCliente(new EntityFrameworkModels.Cliente
                {
                    Ciudad = "MX",
                    Edad = 26,
                    Id = 2509,
                    Nombre = "Esteban GaRo"
                });

            }catch(Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error al registrar al cliente: {ex.Message}");
            }
        }
    }
}
