using Movies.Client.Models;

namespace Movies.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(Guid ID);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task DeleteMovie(Guid ID);
        Task<UserInfoViewModel?> GetUserInfo();
    }
}
