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
