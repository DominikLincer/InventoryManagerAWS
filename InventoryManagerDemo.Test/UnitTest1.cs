using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace InventoryManagerDemo.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            GetSecret();
        }

        public static void GetSecret()
        {
            var secretName = "DatabaseInstanceSecret-AbkrqcK7ftaQ";
            var region = "eu-central-1";

            var client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));
            var request = new GetSecretValueRequest
            {
                SecretId = secretName
            };

            var response = client.GetSecretValueAsync(request).Result;

            if (response.SecretString != null)
            {
                var secret = JsonConvert.DeserializeObject<Client>(response.SecretString);
            }
        }
    }

    public class Client
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
