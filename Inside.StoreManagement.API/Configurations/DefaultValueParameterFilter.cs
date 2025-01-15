using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Persistence;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Inside.StoreManagement.API.Configurations
{
    public class DefaultValueParameterFilter(IServiceProvider serviceProvider) : IParameterFilter
    {
        public void Apply(OpenApiParameter openApiParameter, ParameterFilterContext parameterFilterContext)
        {
            if (openApiParameter.Name == "id" && openApiParameter.Schema.Type == "string")
            {
                using var scope = serviceProvider.CreateScope();
                StoreManagementDbContext ordersDbContext = scope.ServiceProvider.GetRequiredService<StoreManagementDbContext>();

                string lastOrderGuid = ordersDbContext.Orders.OrderBy(o => o.CreatedAt).LastOrDefault().Id.ToString();
                openApiParameter.Example = new OpenApiString(lastOrderGuid);
            }
        }
    }
}