using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class UpdateCustomer
    {
        [FunctionName("update_customer")]
        public static IActionResult Post(
                [HttpTrigger(AuthorizationLevel.Function, "put", Route = "customers")]
                [FromBody] Customer cust,
                [Sql("[dbo].[Customer]",
            ConnectionStringSetting = "Azure_Sql_Connection")] out Customer customer,
                ILogger log)
        {
            customer = cust;
            return new CreatedResult($"api/customers", customer);
        }
    }

}