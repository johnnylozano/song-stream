using Microsoft.EntityFrameworkCore;

namespace SongStream.Models
{
    public class Song{
        public string Id { get; set; }
        public string SongName { get; set; }
        public string SongArtist { get; set; }
        public string ImageSrc { get; set; }
        public string AudioSrc { get; set; }
    }

    class SongDb : DbContext
    {
        public SongDb(DbContextOptions options) : base(options) { }
        public DbSet<Song> Songs { get; set; } = null!;
    }
}