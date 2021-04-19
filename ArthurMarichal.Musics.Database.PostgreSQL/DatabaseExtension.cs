using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArthurMarichal.Musics.Database.PostgreSQL
{
    public static class DatabaseExtension
    {
        //Création de la migration.
        public static void AddMusicDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MusicContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("Music"), opt =>
                    {
                        opt.MigrationsAssembly(typeof(DatabaseExtension).Assembly.FullName);
                    });
            });
        }
    }
}