﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

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
            },
            new()
            {
                ClientId = "movies_mvc_client",
                ClientName = "Movies MVC Web App",
                AllowedGrantTypes = GrantTypes.Code,
                AllowRememberConsent = false,
                RedirectUris = new List<string>()
                {
                    "https://localhost:5002/signin-oidc"
                },
                PostLogoutRedirectUris = new List<string>()
                {
                    "https://localhost:5002/signout-callback-oidc"
                },
                ClientSecrets = new List<Secret>()
                {
                    new("secret".Sha256()),
                },
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new("movieAPI", "Movie API")
        };
        public static IEnumerable<ApiResource> ApiResources => Array.Empty<ApiResource>();
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
        public static List<TestUser> TestUsers => new()
        {
            new TestUser
            {
                SubjectId = Guid.NewGuid().ToString(),
                Username = "enesmetek",
                Password = "enesmetek123",
                Claims = new List<Claim>
                {
                    new(JwtClaimTypes.GivenName, "enesmete"),
                    new(JwtClaimTypes.FamilyName, "kafali")
                }
            }
        };
    }
}
