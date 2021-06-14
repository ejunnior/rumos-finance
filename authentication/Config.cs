namespace Idp
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Security.Claims;
    using IdentityServer4;
    using IdentityServer4.Models;
    using IdentityServer4.Test;

    /// <summary>
    /// Responsible for hold in-memory configuration
    /// </summary>
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(
                    name: "financeapi",
                    displayName: "Finance API",
                    claimTypes: new List<string>() {"role"}),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = "financeapi",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "financeapi",
                        "country"
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource(
                    name: "roles",
                    displayName: "Your Role(s)",
                    claimTypes: new List<string>() {"role"}),
                new IdentityResource(
                    name: "country",
                    displayName: "The country you're living in",
                    claimTypes: new List<string>() {"country"})
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "035929E0-E622-4A9E-A5C3-AAD900DCAE11", //Should be unique at the IDP
                    Username = "ejunnior@gmail.com",
                    Password = "Pa$$w0rd",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Edvaldo"),
                        new Claim("family_name", "Junior"),
                        new Claim("address", "Alberto Sampaio"),
                        new Claim("role", "admin"),
                        new Claim(type: "country", value: "Brazil")
                    }
                }
            };
        }
    }
}