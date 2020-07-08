using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDServer
{
    public static class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiResource> GetApiSources() =>

            new List<ApiResource>
            {
                new ApiResource("APIone"),
                new ApiResource("ClientApp")
            };
         

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client()
                {
                     ClientId = "client_id",
                     ClientSecrets = {new Secret("client_secret".ToSha256())},
                     AllowedGrantTypes = GrantTypes.ClientCredentials,
                     AllowedScopes = { "APIone" }
                },
                new Client()
                {
                     ClientId = "client_id_two",
                     ClientSecrets = {new Secret("client_secret_two".ToSha256())},
                     AllowedGrantTypes = GrantTypes.Code,
                     AllowedScopes = { "APIone" , "ClientApp" , IdentityServer4.IdentityServerConstants.StandardScopes.OpenId , IdentityServer4.IdentityServerConstants.StandardScopes.Profile },
                     RedirectUris = {"https://localhost:44358/signin-oidc" }
                     
                }
            };
    }
}
