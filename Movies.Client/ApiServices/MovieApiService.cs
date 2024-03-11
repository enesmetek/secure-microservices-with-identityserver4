using Movies.Client.Models;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovie(Guid ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            List<Movie> movieList = []; 
            movieList.Add(new Movie()
            {
                ID = Guid.NewGuid(),
                Genre = "Comics",
                Title = "Title",
                Rating = "9.2",
                ImageUrl = "images/src",
                ReleaseDate = DateTime.Now,
                Owner = "ben"
            });
            return await Task.FromResult(movieList);
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
