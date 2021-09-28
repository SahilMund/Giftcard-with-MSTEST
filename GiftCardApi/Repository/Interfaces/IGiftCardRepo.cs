using GiftCardApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftCardApi.Repository.Interfaces
{
    public interface IGiftCardRepo
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<GiftCardModel>> GetAll();

        void Create(GiftCardModel giftCard);
    }
}