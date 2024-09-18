using PruebaTecnica.Seguridad.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Seguridad.Business.Contracts
{
    public interface IAutorizacionBusiness
    {
        Task<AutorizacionE> Token();
    }
}
