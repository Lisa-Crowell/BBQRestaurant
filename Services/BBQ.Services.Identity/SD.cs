using Duende.IdentityServer;
using Duende.IdentityServer.Models;


namespace BBQ.Services.Identity;

public static class SD
{
    public const string Admin = "Admin";
    public const string Customer = "Customer";

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new("bbq", "BBQ Server"),
            new("read", "Read your data."),
            new("write", "Write your data."),
            new("delete", "Delete your data.")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "client",
                ClientSecrets = {new Secret(Environment.GetEnvironmentVariable("CLIENT_SECRETS").Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read", "write", "profile"}
            },

            new()
            {
                ClientId = "bbq",
                ClientSecrets = {new Secret(Environment.GetEnvironmentVariable("CLIENT_SECRETS").Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {Environment.GetEnvironmentVariable("REDIRECT_URIS")},
                PostLogoutRedirectUris = {Environment.GetEnvironmentVariable("POST_LOGOUT_REDIRECT_URIS")},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "bbq"
                }
            }
        };
}