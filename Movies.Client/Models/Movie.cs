namespace Movies.Client.Models
{
    public class Movie
    {
        public Guid ID { get; set; }
        public string Title { get; set; } = null!;
        public string? Genre { get; set; }
        public string? Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? Owner { get; set; }
    }
}
