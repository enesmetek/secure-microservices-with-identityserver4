using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients => new Client[]
        {
            new()
            {
                ClientId = "movieClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "movieAPI" }
            }
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new("movieAPI", "Movie API")
        };
        public static IEnumerable<ApiResource> ApiResources => Array.Empty<ApiResource>();
        public static IEnumerable<IdentityResource> IdentityResources => Array.Empty<IdentityResource>();
        public static List<TestUser> TestUsers => new();
    }
}
