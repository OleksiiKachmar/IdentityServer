// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace AuthorizationServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[] 
            {
                new Client
                {
                    ClientId = "118money",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("118118money.com".Sha256())
                    },
                    AllowedScopes = {"api1"}
                }
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "john",
                    Password = "john's password"
                }
            };
        }
    }
}