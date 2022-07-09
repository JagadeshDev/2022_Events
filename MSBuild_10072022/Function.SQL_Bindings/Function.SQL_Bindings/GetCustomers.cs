using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class GetCustomers
    {
        [FunctionName("get_customers")]
        public static IActionResult Get(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = "customers")] HttpRequest req,
                [Sql("SELECT * FROM [dbo].[Customer]",
            CommandType = System.Data.CommandType.Text,
            ConnectionStringSetting = "Azure_Sql_Connection")] IEnumerable<Customer> result,
                ILogger log)
        {
            log.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

            return new OkObjectResult(result);
        }
    }

}
