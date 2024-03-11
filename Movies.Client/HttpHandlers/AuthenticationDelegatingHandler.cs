using IdentityModel.Client;

namespace Movies.Client.HttpHandlers
{
    public class AuthenticationDelegatingHandler(IHttpClientFactory httpClientFactory, ClientCredentialsTokenRequest tokenRequest) : DelegatingHandler
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly ClientCredentialsTokenRequest _tokenRequest = tokenRequest;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient("IDPClient");

            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
            if (tokenResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the access token!");
            }
            request.SetBearerToken(tokenResponse.AccessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
