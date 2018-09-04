using System.Collections.Generic;
using Calmo.Data.SQLServer;
using ListaTelefonica.Domain;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Repository.DTO;

namespace ListaTelefonica.Repository
{
    public class ContactRepository : Calmo.Data.Repository, IContactRepository
    {
        public IEnumerable<Contact> ListByName(string name)
        {
            var result = this.Data.Db()
                                  .AsProcedure()
                                  .WithParameters(new { name })
                                  .List<ContactDTO>("GetContactsLikeName");

            return result.ToDomain();
        }

        public IEnumerable<Contact> List()
        {
            var result = this.Data.Db()
                             .AsProcedure()
                             .List<ContactDTO>("ListContacts");

            return result.ToDomain();
        }

        public long Add(Contact contact)
        {
            var parameters = new
            {
                name = contact.Name,
                phone = contact.PhoneNumber,
                carrierId = contact.Carrier.Id
            };

            var id = this.Data.Db()
                .WithParameters(parameters)
                .Execute<long>("InsertContact");

            return id;
        }
        //-----------------------------------------
        public void Update(Contact contact)
        {
            var parameters = new
            {
                id = contact.Id,
                name = contact.Name,
                phone = contact.PhoneNumber,
                carrierId = contact.Carrier.Id
            };

            this.Data.Db() //var id = 
                .WithParameters(parameters)
                .Execute("_UpdateContact");
        }
        //-----------------------------------------
        public void Delete(long id)
        {
            this.Data.Db().WithParameters(new {Id = id}).Execute("DeleteContact");
        }
    }
}
