using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.Domain;

namespace ListaTelefonicaApi.Models
{
    public class CarrierModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public static class CarrierModelExtensions
    {
        public static CarrierModel ToModel(this Carrier domain)
        {
            return new CarrierModel
            {
                Id = domain.Id,
                Name = domain.Name,
                Price = domain.Price
            };
        }

        public static IEnumerable<CarrierModel> ToModel(this IEnumerable<Carrier> carriers)
        {
            return carriers.Select(carrier => carrier.ToModel()).ToList();
        }
    }
}