using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Company.Function
{
    public static class AddCustomer
    {

        //[FunctionName("add_customers")]
        //public static IActionResult Post(
        //        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "customers")] HttpRequest req,
        //        [Sql("[dbo].[Customer]",
        //    CommandType = System.Data.CommandType.Text,
        //    ConnectionStringSetting = "Azure_Sql_Connection")] out Customer customer,
        //        ILogger log)
        //{
        //    customer = new Customer()
        //    {
        //        CustomerId = "C002",
        //        CustomerName = "Sanvi",
        //        CustomerPhone = "1234567890"
        //    };

        //    return new CreatedResult($"api/customers", customer);
        //}

        [FunctionName("add_customers")]
        public static IActionResult Post(
                [HttpTrigger(AuthorizationLevel.Function, "post", Route = "customers")]
                [FromBody] Customer cust,
                [Sql("[dbo].[Customer]",
            ConnectionStringSetting = "Azure_Sql_Connection")] out Customer customer,
                ILogger log)
        {
            customer = cust;
            return new CreatedResult($"api/customers", customer);
        }

        //[FunctionName("add_customers")]
        //public static async Task<IActionResult> Post(
        //        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "customers")]
        //        [FromBody] Customer[] custs,
        //        [Sql("[dbo].[Customer]",
        //    ConnectionStringSetting = "Azure_Sql_Connection")] IAsyncCollector<Customer> customers,
        //        ILogger log)
        //{
        //    foreach (var cust in custs)
        //    {
        //        await customers.AddAsync(cust);
        //    }

        //    return new CreatedResult($"api/customers", "done");
        //}
    }

}