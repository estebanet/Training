using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types

namespace WebApp_QueueMessages.Models
{
    public class QueueStorageManager
    {
        private CloudStorageAccount storageAccount;
        private CloudQueueClient queueClient;
        private CloudQueue queue;

        public QueueStorageManager()
        {
            storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageAccount"));
            queueClient = storageAccount.CreateCloudQueueClient();
        }

        private async Task CreateQueueIfNotExists(string queueName)
        {
            if (queueClient == null)
                throw new NotSupportedException("Se debe inicializar la propiedad de cliente de colas");

            if (queue == null || queue.Name.ToLower() != queueName.ToLower())
            {
                queue = queueClient.GetQueueReference(queueName);
                await queue.CreateIfNotExistsAsync();
            }
        }

        public async Task RegisterMessage(string message, string queueName)
        {
            await CreateQueueIfNotExists(queueName);
            CloudQueueMessage Message = new CloudQueueMessage(message);
            await queue.AddMessageAsync(Message);
        }
    }
}