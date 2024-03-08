using Movies.API.Core.Domain.Abstract;

namespace Movies.API.Core.Domain.Concrete
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Genre { get; set; }
        public string? Rating { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? Owner { get; set; }
    }
}
    