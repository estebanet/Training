using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.Azure.Storage; // Namespace for StorageAccounts
using Microsoft.Azure.CosmosDB.Table; // Namespace for Table storage types

namespace Microsoft_Azure_Table_Storage_Emulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string TablaReferencia = "personas";

            //InsertAnEntityInTable(TablaReferencia);
            //InsertEntitiesInBatchTableOperation(TablaReferencia);
            QueryEntitiesWithSamePartitionKey(TablaReferencia);

            // Continue with "Retrieve a range of entities in a partition" section.
            Console.WriteLine("Presione <enter> para continuar...");
            Console.ReadLine();
        }

        static void QueryEntitiesWithSamePartitionKey(string TablaReferencia)
        {
            CloudStorageAccount cuenta = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("CadenaConexionAlmacenamiento"));
            CloudTableClient clienteT = cuenta.CreateCloudTableClient();
            CloudTable tabla = clienteT.GetTableReference(TablaReferencia);
            tabla.CreateIfNotExists();

            TableQuery<Entidades.ClientePersonalizado> consulta =
                new TableQuery<Entidades.ClientePersonalizado>().Where(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Estudiante"));

            foreach (var estudiante in tabla.ExecuteQuery(consulta))
            {
                Console.WriteLine($"Nombre: {estudiante.RowKey}, Puesto: " +
                    $"{estudiante.PartitionKey}, Nacimiento: {estudiante.FechaNacimiento.ToString("dd/MM/yyyy")}");
            }
        }

        static void InsertEntitiesInBatchTableOperation(string TablaReferencia)
        {
            CloudStorageAccount cuenta = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("CadenaConexionAlmacenamiento"));
            CloudTableClient clienteT = cuenta.CreateCloudTableClient();
            CloudTable tabla = clienteT.GetTableReference(TablaReferencia);
            tabla.CreateIfNotExists();

            TableBatchOperation loteOperacion = new TableBatchOperation();

            Entidades.ClientePersonalizado cliente1 = new Entidades.ClientePersonalizado(
                "Fernando", "Estudiante"), cliente2 = new Entidades.ClientePersonalizado(
                    "Victor", "Estudiante");
            cliente2.Direccion = cliente1.Direccion = "Onofre Capeto 78";
            cliente2.FechaNacimiento = cliente1.FechaNacimiento = new DateTime(1999, 5, 3);
            
            loteOperacion.Insert(cliente1);
            loteOperacion.Insert(cliente2);

            tabla.ExecuteBatch(loteOperacion);
        }

        static void InsertAnEntityInTable(string TablaReferencia)
        {
            CloudStorageAccount CuentaDeAlmacenamiento = GetCloudStorageAccount();
            CloudTableClient ClienteTablas = GetCloudTableClient(CuentaDeAlmacenamiento);

            CloudTable Tabla = ClienteTablas.GetTableReference(TablaReferencia);
            bool EsTablaCreada = Tabla.CreateIfNotExists();

            if (EsTablaCreada)
            {
                Console.WriteLine($"Se ha creado la tabla {TablaReferencia}");
            }
            Entidades.ClientePersonalizado Cliente = new Entidades.ClientePersonalizado("Amber GaRo",
                "Aplicadora");
            Cliente.Direccion = "Onofre Capeto #78";
            Cliente.FechaNacimiento = new DateTime(1994, 12, 24);
            Cliente.Sexo = "H";

            TableOperation InsertarClienteOperacion = TableOperation.Insert(Cliente);
            Tabla.Execute(InsertarClienteOperacion);
        }

        static CloudStorageAccount GetCloudStorageAccount()
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("CadenaConexionAlmacenamiento"));

            return storageAccount;
        }

        static CloudTableClient GetCloudTableClient(CloudStorageAccount storageAccount)
        {
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            return tableClient;
        }


    }


}
