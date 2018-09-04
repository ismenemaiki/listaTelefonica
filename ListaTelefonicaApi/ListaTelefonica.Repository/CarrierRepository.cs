using Calmo.Data.SQLServer;
using System.Collections.Generic;
using ListaTelefonica.Repository.DTO;
using ListaTelefonica.Domain;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Repository
{
    public class CarrierRepository : Calmo.Data.Repository, ICarrierRepository
    {
        public IEnumerable<Carrier> List()
        {
            var result = this.Data.Db().AsProcedure().List<CarrierDTO>("ListCarriers");
            return result.ToDomain();
        }
    }
}
