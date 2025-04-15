using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PickMyMovie.Infrastructure.DataAccess;
using static System.Formats.Asn1.AsnWriter;

namespace PickMyMovie.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public async static Task MigrateDataBase(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<PickMyMovieDbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
