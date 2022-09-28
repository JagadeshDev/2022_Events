using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Company.Function
{
    public static class GetCustomerById
    {
        [FunctionName("get_customer_by_id")]
        public static IActionResult Get(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = "customers/{id}")] HttpRequest req,
                [Sql("%My_Procedure%",
            CommandType = System.Data.CommandType.StoredProcedure,
            Parameters ="@Id={id}",
            ConnectionStringSetting = "Azure_Sql_Connection")] IEnumerable<Customer> result,
                ILogger log)
        {
            log.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

            return new OkObjectResult(result);
        }

        //[FunctionName("get_customer_by_id")]
        //public static IActionResult Get(
        //        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "customers/{id}")] HttpRequest req,
        //        [Sql("SELECT * FROM [dbo].[Customer] WHERE CustomerId= @Id",
        //    CommandType = System.Data.CommandType.Text,
        //    Parameters ="@Id={id}",
        //    ConnectionStringSetting = "Azure_Sql_Connection")] IEnumerable<Customer> result,
        //        ILogger log)
        //{
        //    log.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

        //    return new OkObjectResult(result);
        //}
    }

}
