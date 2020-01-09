using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4.Web
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="AuthWeb",
                    ClientName="AuthWeb Demo Client",
                    AllowedGrantTypes=GrantTypes.Implicit,
                    RedirectUris={ "https://localhost:44306/signin-oidc"},
                    PostLogoutRedirectUris=new List<string>{ "https://localhost:44306/signout-callback-oidc"},
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client
                {
                    ClientId="AuthApi",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    ClientName="AuthApi Demo Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent=false,
                    RequirePkce=true,
                    RedirectUris = { "https://localhost:44306/signin-oidc" },
                    PostLogoutRedirectUris=new List<string>{ "https://localhost:44306/signout-callback-oidc"},
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api"
                    },
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser=true
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="admin",
                    Password="serenity",
                    Claims=new[]
                    {
                        new Claim("name","admin")
                    }
                },
                new TestUser
                {
                    SubjectId="2",
                    Username="samdubey",
                    Password="serenity",
                    Claims=new[]
                    {
                        new Claim("name","samdubey")
                    }
                }
            };
        }
    }
}
