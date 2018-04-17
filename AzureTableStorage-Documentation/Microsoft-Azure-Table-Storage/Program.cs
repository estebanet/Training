using Microsoft.Azure;
using Microsoft.Azure.CosmosDB.Table;
using Microsoft.Azure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Azure_Table_Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var consulta =
                    ObtenEquipo("Cruz Azul");
                    //ObtenEquiposConMasDe7Campeonatos();
                //ObtenEquipos();
                //foreach (Modelo.Equipo equipo in consulta)
                //{
                    Console.WriteLine($"Nombre: {consulta.RowKey}, " +
                        $"Apodo: {consulta.Apodo}, Campeonatos: {consulta.NoCampeonatos}, " +
                        $"Fundación: {consulta.Fundacion.ToShortDateString()}");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido la siguiente excepción: {ex.Message}");
            }

            Console.WriteLine("Presione <enter> para continuar");
            Console.ReadLine();
        }

        static Modelo.Equipo ObtenEquipo(string nombre, string liga = "Liga MX")
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("ConexionGaroNetStorage"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("CosasParaBorrarTable");

            TableOperation tableOperation = TableOperation.Retrieve<Modelo.Equipo>(liga, nombre);

            var equipo = cloudTable.Execute(tableOperation);

            return equipo.Result as Modelo.Equipo;
        }

        static List<Modelo.Equipo> ObtenEquiposConMasDe7Campeonatos()
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("ConexionGaroNetStorage"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("CosasParaBorrarTable");

            TableQuery<Modelo.Equipo> queryEquipos = new TableQuery<Modelo.Equipo>()
                .Where(TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Liga MX"),
                    TableOperators.And,
                    TableQuery.GenerateFilterConditionForInt("NoCampeonatos", QueryComparisons.GreaterThan, 7)));

            var tableStorageQuery = 
                cloudTable.ExecuteQuery<Modelo.Equipo>(queryEquipos).ToList();

            return tableStorageQuery;
        }

        static List<Modelo.Equipo> ObtenEquipos()
        {
            CloudStorageAccount storageAccount = 
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("ConexionGaroNetStorage"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("CosasParaBorrarTable");

            TableQuery<Modelo.Equipo> queryEquipos =
                new TableQuery<Modelo.Equipo>()
                    .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Liga MX"));

            var tableStorageQuery = cloudTable.ExecuteQuery<Modelo.Equipo>(queryEquipos).ToList();

            return tableStorageQuery;
        }

        static void InsertSingleEntityAndBatchOperation()
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("ConexionGaroNetStorage"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable cloudTable = tableClient.GetTableReference("CosasParaBorrarTable");
            cloudTable.CreateIfNotExists();

            Modelo.Equipo equipoTE = new Modelo.Equipo("Pachuca", "Liga MX");
            equipoTE.Apodo = "Los Tuzos del Pachuca";
            equipoTE.NoCampeonatos = 6;
            equipoTE.Fundacion = new DateTime(2000, 11, 28);

            Modelo.Equipo equipoTE2 = new Modelo.Equipo("Guadalajara", "Liga MX");
            equipoTE2.Apodo = "Las chivas rayadas del guadalajara";
            equipoTE2.NoCampeonatos = 12;
            equipoTE2.Fundacion = new DateTime(2000, 5, 8);

            TableBatchOperation tableOperation = new TableBatchOperation();
            tableOperation.Insert(equipoTE);
            tableOperation.Insert(equipoTE2);

            cloudTable.ExecuteBatch(tableOperation);
        }
    }
}
