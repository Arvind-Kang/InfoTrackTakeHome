namespace InfoTrackTakeHome.Server.Contexts
{
    using Microsoft.EntityFrameworkCore;

    public class InfoTrackContext : DbContext
    {
        public DbSet<SearchResult> SearchResults { get; set; }

        public InfoTrackContext(DbContextOptions<InfoTrackContext> options) : base(options) { }
    }

    public class SearchResult
    {
        public int Id { get; set; }
        public required string SearchPhrase { get; set; }
        public required string Url { get; set; }
        public required string Result { get; set; }
        public DateTime SearchDate { get; set; }
    }

}
