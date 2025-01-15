using Inside.StoreManagement.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Inside.StoreManagement.API.Configurations
{
    public class DefaultValueOperationFilter(IServiceProvider serviceProvider) : IOperationFilter
    {
        public void Apply(OpenApiOperation openApiOperation, OperationFilterContext operationFilterContext)
        {
            if (openApiOperation.RequestBody?.Content.ContainsKey("application/json") == true)
            {
                OpenApiMediaType openApiMediaType = openApiOperation.RequestBody.Content["application/json"];

                if (openApiMediaType.Schema?.Reference != null)
                {
                    var schemaId = openApiMediaType.Schema.Reference.Id;

                    if (schemaId == "AddProductToOrderCommand")
                    {
                        using var scope = serviceProvider.CreateScope();
                        StoreManagementDbContext ordersDbContext = scope.ServiceProvider.GetRequiredService<StoreManagementDbContext>();

                        string lastOrderGuid = ordersDbContext.Orders.OrderBy(o => o.CreatedAt).LastOrDefault().Id.ToString();
                        string lastProductGuid = ordersDbContext.Products.OrderBy(o => o.CreatedAt).LastOrDefault().Id.ToString();

                        openApiMediaType.Example = new OpenApiObject
                        {
                            ["orderId"] = new OpenApiString(lastOrderGuid),
                            ["productId"] = new OpenApiString(lastProductGuid)
                        };
                    }
                }
            }
        }
    }
}