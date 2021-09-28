using System.ComponentModel.DataAnnotations;

namespace GiftCardApi.Models.Dtos
{
    public class GiftCardReadDto
    {
        [Key]
        [Required]
        public int GiftCardId { get; set; }

        [Required]
        public string BuyerName { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}