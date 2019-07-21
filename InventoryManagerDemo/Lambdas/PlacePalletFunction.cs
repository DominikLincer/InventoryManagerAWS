using Amazon.Lambda.APIGatewayEvents;
using InventoryManagerDemo.Base;
using InventoryManagerDemo.BLL.Services;
using InventoryManagerDemo.Client.Requests;
using Newtonsoft.Json;
using System.Net;

namespace InventoryManagerDemo.Lambdas
{
    public class PlacePalletFunction : BaseLambdaFunction
    {
        public APIGatewayProxyResponse PlacePallet(LambdaRequest lambdaRequest)
        {
            var palletService = new PalletService();
            var placePalletRequest = JsonConvert.DeserializeObject<PlacePalletRequest>(lambdaRequest.Body);
            palletService.PlacePallet(placePalletRequest);

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
