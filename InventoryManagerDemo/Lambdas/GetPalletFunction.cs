using Amazon.Lambda.APIGatewayEvents;
using InventoryManagerDemo.Base;
using InventoryManagerDemo.BLL.Services;
using Newtonsoft.Json;
using System.Net;

namespace InventoryManagerDemo.Lambdas
{
    public class GetPalletFunction : BaseLambdaFunction
    {
        public APIGatewayProxyResponse GetPallet(APIGatewayProxyRequest request)
        {
            if (request.PathParameters != null && request.PathParameters.ContainsKey("palletId") 
                && int.TryParse(request.PathParameters["palletId"], out var palletId))
            {
                var palletService = new PalletService();
                var getPalletResposne = palletService.GetPallet(palletId);

                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body = JsonConvert.SerializeObject(getPalletResposne)
                };
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }
    }
}
