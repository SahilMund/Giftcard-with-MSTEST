using System.ComponentModel.DataAnnotations;

namespace GiftCardApi.Models.Dtos
{
    public class GiftCardCreateDto
    {
        [Required]
        public string BuyerName { get; set; }

        [Required]
        public string RecipientName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PinCode { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Occassion { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}