using AutoMapper;
using GiftCardApi.Models.Dtos;

namespace GiftCardApi.Models.Profiles
{
    public class GiftCardProfile : Profile
    {
        public GiftCardProfile()
        {
            CreateMap<GiftCardModel, GiftCardReadDto>();
            CreateMap<GiftCardCreateDto, GiftCardModel>();
        }
    }
}