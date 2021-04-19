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
            builder.HasKey("Title");
            builder.Property(Music => Music.Title)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(Music => Music.Artist)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(Music => Music.Album)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}