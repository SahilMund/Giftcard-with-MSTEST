using GiftCardApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftCardApi.Repository
{
    public class GiftCardContext : DbContext
    {
        public GiftCardContext(DbContextOptions<GiftCardContext> options) : base(options)
        { }

        public DbSet<GiftCardModel> GiftCards { get; set; }
    }
}