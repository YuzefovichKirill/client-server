using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Server.Identity
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("ServerWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("ServerWebAPI", "Web API", new []
                    {JwtClaimTypes.Email})
                // or JwtClaimTypes.Name
                {
                    Scopes = { "ServerWebAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "angular-web-app",
                    ClientName = "Angular client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =
                    {
                        "http://localhost:4200/signin-callback"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:4200"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:4200/signout-callback"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ServerWebAPI"
                    }
                }
            };
    }
}
