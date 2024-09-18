using PruebaTecnica.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Service.Contracts
{
    public interface IProveedorQueries
    {
        Task<List<ProveedoresCollection>> ListarProveedor();
        Task<ProveedoresCollection> DetalleProveedor(string id);
    }
}
