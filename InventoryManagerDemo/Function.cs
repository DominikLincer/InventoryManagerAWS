using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using InventoryManagerDemo.Database;
using InventoryManagerDemo.Database.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace InventoryManagerDemo
{
    public class Functions
    {
        public Functions()
        {
        }
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            using (var dbContext = new InventoryManagerContext())
            {
                context.Logger.LogLine("Connected to db");
                dbContext.Pallets.Add(new Pallet
                {
                    IsPlaced = false,
                    Weight = 75,
                    Size = new Size
                    {
                        Heigh = 100,
                        Width = 100,
                        Length = 50
                    }
                });

                context.Logger.LogLine("Pallet added");

                dbContext.SaveChanges();

                context.Logger.LogLine("Changes saved");
            }

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(new TestResponse
                {
                    Name = "test",
                    Value = 10
                }),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }
    }

    public class TestResponse
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
