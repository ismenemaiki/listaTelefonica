using System.Collections.Generic;

namespace ListaTelefonica.Domain.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> ListByName(string name);
        IEnumerable<Contact> List();
        long Add(Contact contact);
        void Delete(long id);
        void Update(Contact contact);
                
    }
}
