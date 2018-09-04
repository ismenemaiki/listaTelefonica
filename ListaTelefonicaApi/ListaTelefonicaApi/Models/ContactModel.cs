using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.Domain;

namespace ListaTelefonicaApi.Models
{
    public class ContactModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public CarrierModel Carrier { get; set; }

        public Contact ToDomain()
        {
            return new Contact
            {
                Id = this.Id,
                Name = this.Name,
                PhoneNumber = this.PhoneNumber,
                Carrier = new Carrier
                {
                    Id = this.Carrier.Id,
                    Name = this.Carrier.Name,
                    Price = this.Carrier.Price
                }
            };
        }
    }

    public static class ContactModelExtensions
    {
        public static ContactModel ToModel(this Contact domain)
        {
            return new ContactModel
            {
                Id = domain.Id,
                Name = domain.Name,
                PhoneNumber = domain.PhoneNumber,
                Carrier = new CarrierModel
                {
                    Id = domain.Carrier.Id,
                    Name = domain.Carrier.Name,
                    Price = domain.Carrier.Price
                }
            };
        }

        public static IEnumerable<ContactModel> ToModel(this IEnumerable<Contact> contacts)
        {
            return contacts.Select(contact => contact.ToModel()).ToList();
        }
    }
}