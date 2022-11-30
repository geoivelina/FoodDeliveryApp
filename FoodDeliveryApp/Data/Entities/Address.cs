using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.Address;
namespace FoodDeliveryApp.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NeighbourhoodMaxLenght)]
        public string Neighbourhood { get; set; }

        [Required]
        [StringLength(StreetNameMaxLength)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(StreetNumberMaxLength)]
        public string StreetNumber { get; set; }

        [Required]
        [StringLength(AppartmentNumberMaxLength)]
        public string AppartmentNumber { get; set; }

        [Required]
        [StringLength(PostCodeMaxLength)]
        public string PostCode { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
       

    }
}
