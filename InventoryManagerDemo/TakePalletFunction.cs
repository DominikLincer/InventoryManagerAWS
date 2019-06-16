using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using InventoryManagerDemo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace InventoryManagerDemo
{
    public class TakePalletFunction
    {
        //public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        //{
        //    using (var dbContext = new InventoryManagerContext())
        //    {
        //        dbContext.Pallets.SingleOrDefault(x => x.Id == request.Body.)

        //        dbContext.SaveChanges();
        //    }

        //    var response = new APIGatewayProxyResponse
        //    {
        //        StatusCode = (int)HttpStatusCode.OK,
        //        Body = JsonConvert.SerializeObject(new TestResponse
        //        {
        //            Name = "test",
        //            Value = 10
        //        }),
        //        Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
        //    };

        //    return response;
        //}
    }
}
