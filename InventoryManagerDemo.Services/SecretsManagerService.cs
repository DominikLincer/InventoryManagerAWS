using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using InventoryManagerDemo.Services.Models;
using Newtonsoft.Json;
using System;

namespace InventoryManagerDemo.Services
{
    public class SecretsManagerService
    {
        public DbUserModel GetSecretAsync()
        {
            var secretName = "DatabaseInstanceSecret-8LfFApTezOAE";
            var region = "eu-central-1";
            var client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));
            var request = new GetSecretValueRequest
            {
                SecretId = secretName,
            };

            var response = client.GetSecretValueAsync(request).Result;
            if (response.SecretString == null)
            {
                throw new ArgumentNullException(response.SecretString);
            }

            return JsonConvert.DeserializeObject<DbUserModel>(response.SecretString);
        }
    }
}
