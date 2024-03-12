using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movies.Client.Models;
using Newtonsoft.Json;
using System.Text;

namespace Movies.Client.ApiServices
{
    public class MovieApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : IMovieApiService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
            
        public async Task<IEnumerable<Movie>?> GetMovies()
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/movies/");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            List<Movie>? movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
            return movieList;
        }

        public async Task<Movie?> GetMovie(Guid ID)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/movies/{ID}");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Movie? movie = JsonConvert.DeserializeObject<Movie>(content);
            return movie;
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/movies/");
            request.Content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
            await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            return movie;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");
            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/movies/{movie.ID}");
            request.Content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
            await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            return movie;
        }

        public async Task DeleteMovie(Guid ID)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/movies/{ID}");
            await httpClient.SendAsync(request, new HttpCompletionOption()).ConfigureAwait(false);
        }

        public async Task<UserInfoViewModel?> GetUserInfo()
        {
            var idpClient = _httpClientFactory.CreateClient("IDPClient");
            var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();
            if (metaDataResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the access token!");
            }
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var userInfoResponse = await idpClient.GetUserInfoAsync(new UserInfoRequest
                {
                    Address = metaDataResponse.UserInfoEndpoint,
                    Token = accessToken
                });
            if (userInfoResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while getting the user info!");
            }
            var userInfoDictionary = new Dictionary<string, string>();
            foreach (var claim in userInfoResponse.Claims)
            {
                userInfoDictionary.Add(claim.Type, claim.Value);
            }
            return new UserInfoViewModel(userInfoDictionary);
        }
    }
}
