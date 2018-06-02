using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkModels.Repositories
{
    public class ClientesDBContext
    {
        private string ConnectionString;

        public ClientesDBContext()
        {
            ConnectionString = string.Empty;
        }

        public ClientesDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Método que almacena un cliente en la entidad dbo.Clientes
        /// </summary>
        /// <param name="cliente">Entidad a almacenar.</param>
        /// <returns></returns>
        public void RegistraCliente(Cliente cliente)
        {
            using (ClientEFModelsContainer dbContext =
                string.IsNullOrEmpty(ConnectionString) ?
                    new ClientEFModelsContainer() :
                    new ClientEFModelsContainer(ConnectionString))
            {
                dbContext.Clientes.Add(cliente);
                dbContext.SaveChanges();
            }
        }
    }
}
