using Focus.Infrastructure;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Focus.Auth
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource(AppSetting.ApiName, AppSetting.DisplayName)
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Focus.Client.HybridAndClientCredentials",
                    ClientName = AppSetting.DisplayName,
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets = { new Secret(AppSetting.ClientSecret.Sha256()) },
                    RedirectUris = { AppSetting.WebUrl + "/signin-oidc" },
                    PostLogoutRedirectUris = { AppSetting.WebUrl + "/signout-callback-oidc"},
                    AllowedScopes =
                    {
                        AppSetting.ApiName,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
    }
}
