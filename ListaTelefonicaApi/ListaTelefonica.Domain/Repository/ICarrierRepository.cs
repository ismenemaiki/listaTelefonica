using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefonica.Domain.Repository
{
    public interface ICarrierRepository
    {
        IEnumerable<Carrier> List();
    }
}
