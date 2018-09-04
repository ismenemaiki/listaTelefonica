using ListaTelefonica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefonica.Repository.DTO
{
    public class CarrierDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Carrier ToDomain()
        {
            return new Carrier
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price

            };
        }
    }

    public static class CarrierDTOExtensions
    {
        public static IEnumerable<Carrier> ToDomain(this IEnumerable<CarrierDTO> dtos)
        {
            return dtos.Select(d => d.ToDomain());
        }
    }
}
