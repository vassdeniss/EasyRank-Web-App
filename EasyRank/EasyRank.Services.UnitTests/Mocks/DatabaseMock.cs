using EasyRank.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace EasyRank.Services.UnitTests.Mocks
{
    public static class DatabaseMock
    {
        public static EasyRankDbContext Instance
        {
            get
            {
                DbContextOptionsBuilder<EasyRankDbContext> optionsBuilder = 
                        new DbContextOptionsBuilder<EasyRankDbContext>();

                optionsBuilder.UseInMemoryDatabase($"EasyRank-TestDb-{DateTime.Now.Ticks}");

                return new EasyRankDbContext(optionsBuilder.Options, false);
            }
        }
    }
}
