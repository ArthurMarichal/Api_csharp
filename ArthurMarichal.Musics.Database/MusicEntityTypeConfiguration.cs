using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArthurMarichal.Musics.Database
{
    public class MusicEntityTypeConfiguration  :  IEntityTypeConfiguration<Music>
    
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            //Je créé ma table et ses colonnes.
            builder.ToTable("Music");
            builder.HasKey(music => music.Id);
            builder.Property(music => music.Title)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(music => music.Artist)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(music => music.Album)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}