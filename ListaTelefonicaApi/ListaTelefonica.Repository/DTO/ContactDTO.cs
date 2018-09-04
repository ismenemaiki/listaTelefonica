using System;
using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.Domain;

namespace ListaTelefonica.Repository.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }

        public Contact ToDomain()
        {
            return new Contact
            {
                Id = this.Id,
                Name = this.Name,
                PhoneNumber = this.PhoneNumber,
                Carrier = new Carrier
                {
                    Id = this.CarrierId,
                    Name = this.CarrierName
                }
            };
        }
    }

    public static class ContactDTOExtensions
    {
        public static IEnumerable<Contact> ToDomain(this IEnumerable<ContactDTO> dtos)
        {
            return dtos.Select(d => d.ToDomain());
        }
    }
}
