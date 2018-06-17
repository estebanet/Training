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
                #region Documentación 1.0
                //var consulta =
                //    //ObtenEquipo("Cruz Azul");
                ////ObtenEquiposConMasDe7Campeonatos();
                //ObtenEquipoConMasDe5Campeonatos("CosasParaBorrarTable");
                ////ObtenEquipos();
                //foreach (Modelo.Equipo equipo in consulta)
                //{
                //    Console.WriteLine($"Nombre: {equipo.RowKey}, " +
                //        $"Apodo: {equipo.Apodo}, Campeonatos: {equipo.NoCampeonatos}, " +
                //        $"Fundación: {equipo.Fundacion.ToShortDateString()}");
                //}
                //InsertaEquipoIngles("CosasParaBorrarTable");
                #endregion

                #region Documentación 2.0

                #region Inserts (one entity and insert batch operations)

                Modelo.Equipo Equipo = new Modelo.Equipo("México", "Mundial");
                Equipo.Apodo = "Equipo mexicano";
                Equipo.IdEquipo = 1;
                Equipo.NoCampeonatos = 0;

                Console.WriteLine("Registrando equipo");
                InsertEquipoEntity(Equipo);
                Console.WriteLine("Registrando equipos");
                Modelo.Equipo Equipo2 = new Modelo.Equipo("Corea del Sur", "Mundial");
                Modelo.Equipo Equipo3 = new Modelo.Equipo("Alemania", "Mundial");
                Equipo2.Apodo = "coreanos";
                Equipo2.IdEquipo = 2;
                Equipo.NoCampeonatos = 0;
                Equipo3.Apodo = "La máquina alemana";
                Equipo3.IdEquipo = 3;
                Equipo3.NoCampeonatos = 4;
                InsertEquipoEntities(new List<Modelo.Equipo> { Equipo2, Equipo3 });

                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido la siguiente excepción: {ex.Message}");
            }

            Console.WriteLine("Presione <enter> para continuar");
            Console.ReadLine();
        }

        #region Documentación 1.0

        static void InsertaEquipoIngles(string Tabla, string liga = "Liga Premier")
        {
            CloudStorageAccount account = CloudStorageAccount.
                Parse(CloudConfigurationManager.GetSetting("ConexionGaroNetStorage"));
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(Tabla);

            Modelo.EquipoIngles equipoIngles = new Modelo.EquipoIngles
            {
                Copas = 15,
                Liga = liga,
                Nombre = "Manchester United"
            };

            Modelo.Equipo equipoMexicano = new Modelo.Equipo("Lobos UAP", "Liga MX");
            equipoMexicano.Apodo = "Lobos";
            equipoMexicano.Fundacion = DateTime.Today;
            equipoMexicano.IdEquipo = 30;
            equipoMexicano.NoCampeonatos = 0;

            List<TableOperation> operacionesTabla = new List<TableOperation>
            {
                TableOperation.Insert(equipoIngles),
                TableOperation.Insert(equipoMexicano)
            };

            //var result1 = table.Execute(operacionesTabla[0]);
            var result2 = table.Execute(operacionesTabla[1]);

        }

        static List<Modelo.Equipo> ObtenEquipoConMasDe5Campeonatos(string Tabla, string liga = "Liga MX")
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("ConexionGaroNetStorage"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable cloudTable = tableClient.GetTableReference(Tabla);

            TableQuery<Modelo.Equipo> queryTable = new TableQuery<Modelo.Equipo>().Where(
                TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, liga),
                TableOperators.And,
                TableQuery.GenerateFilterConditionForInt("NoCampeonatos", QueryComparisons.GreaterThanOrEqual, 5)
                ));

            List<Modelo.Equipo> equipos = cloudTable.ExecuteQuery(queryTable).ToList();

            return equipos;
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

        #endregion

        #region Documentación 2.0

        #region Inserts (one entity and insert batch operations)

        private static void InsertEquipoEntity(Modelo.Equipo entity)
        {
            try
            {
                // Se crea cuenta de almacenamiento para obtener el cliente de servicio de tablas de azure.
                CloudStorageAccount StorageAccount_garo = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("ConexionGaroNetStorage"));
                // Se crea cliente de servicio de tablas de azure, para crear/obtener referencia una tabla de azure.
                CloudTableClient TableClient = StorageAccount_garo.CreateCloudTableClient();
                // Se crea/obtiene referencia a tabla de azure.
                CloudTable Table = TableClient.GetTableReference("Mundial");
                // Se asegura la existencia de la tabla de azure recién obtenida.
                Table.CreateIfNotExists();
                // Se crea entidad a registrar.
                //Modelo.Equipo Equipo = new Modelo.Equipo("México", "Mundial");
                //Equipo.Apodo = "Equipo mexicano";
                //Equipo.IdEquipo = 1;
                //Equipo.NoCampeonatos = 0;
                // Se crea operación de tabla, para registrar entidad Equipo.
                TableOperation InsertEquipo = TableOperation.Insert(entity);
                // Se ejecuta operación de tabla.
                TableResult InsertResult = Table.Execute(InsertEquipo);
                // Se muestran resultados de operación por consola.
                Console.WriteLine("Se ha registrado exitosamente el equipo:");
                Console.WriteLine(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha fallado la inserción de equipo, " +
                    $"Error: {ex.Message}");
            }
        }

        private static void InsertEquipoEntities(List<Modelo.Equipo> entities)
        {
            try
            {
                CloudStorageAccount StorageAccount = 
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("ConexionGaroNetStorage"));
            CloudTableClient TableClient = StorageAccount.CreateCloudTableClient();
            CloudTable Table = TableClient.GetTableReference("Mundial");
            Table.CreateIfNotExists();
            TableBatchOperation BatchOperation = new TableBatchOperation();
            entities.ForEach(Equipo => BatchOperation.Insert(Equipo));
            Table.ExecuteBatch(BatchOperation);
            Console.WriteLine("Se han registrado los equipos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha fallado la inserción de equipos, " +
                    $"Error: {ex.Message}");
            }
        }

        #endregion

        #endregion
    }
}
