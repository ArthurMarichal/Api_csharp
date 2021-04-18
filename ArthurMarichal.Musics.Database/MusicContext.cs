using Microsoft.EntityFrameworkCore;

namespace ArthurMarichal.Musics.Database
{
    public class MusicContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        
        public MusicContext(DbContextOptions<MusicContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MusicEntityTypeConfiguration());
        }
    }
}