using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class GetOrders
    {
        [FunctionName("get_orders")]
        public static IActionResult Get(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = "customers/{id}/orders")] HttpRequest req,
                [Sql("SELECT * FROM [dbo].[Orders] WHERE CustomerId=@CustomerId",
            CommandType = System.Data.CommandType.Text,
            Parameters ="@CustomerId={id}",
            ConnectionStringSetting = "Azure_Sql_Connection")] IEnumerable<Order> result,
                ILogger log)
        {
            log.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

            return new OkObjectResult(result);
        }
    }

}
