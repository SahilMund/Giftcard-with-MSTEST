using GiftCardApi.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftCardApi.Services.Interfaces
{
    public interface IGiftCardServices
    {
        Task<IEnumerable<GiftCardReadDto>> GetAll();

        Task<GiftCardReadDto> Create(GiftCardCreateDto giftCardCreateDto);
    }
}