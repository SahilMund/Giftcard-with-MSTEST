using GiftCardApi.CustomExceptions;
using GiftCardApi.Models.Dtos;
using GiftCardApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftCardApi.Controllers
{
    [Route("api/giftcards")]
    [ApiController]
    public class GiftCardsController : ControllerBase
    {
        private readonly IGiftCardServices _services;

        public GiftCardsController(IGiftCardServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<GiftCardReadDto>> GetAll()
        {
            List<GiftCardReadDto> giftCards;
            try
            {
                giftCards = await _services.GetAll() as List<GiftCardReadDto>;
            }
            catch (NoDataAvailableException ndae)
            {
                // TODO log the exception
                return null;
            }
            return giftCards;
        }

        [HttpPost]
        public async Task<string> Create(GiftCardCreateDto giftCardCreateDto)
        {
            GiftCardReadDto giftCard = await _services.Create(giftCardCreateDto);

            if (giftCard == null)
            {
                return "Gift card addition unsuccessfull";
            }
            return "Gift card added successfully";
        }
    }
}