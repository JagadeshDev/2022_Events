using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using System.Net;

namespace ProductsAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IDynamoDBContext _dynamoDbContext;

        public ProductController(ILogger<ProductController> logger, IDynamoDBContext dynamoDbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _dynamoDbContext = dynamoDbContext ?? throw new ArgumentNullException(nameof(dynamoDbContext));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            _logger.LogInformation("Received the ProductsController::Post() request.");

            try
            {
                product.Id = $"{Guid.NewGuid()}";
                await _dynamoDbContext.SaveAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            _logger.LogInformation("Sending output from ProductsController::Post() request.");

            return Created("", product);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            _logger.LogInformation("Received the ProductsController::Get() request.");

            // Get the Table ref from the Model
            var table = _dynamoDbContext.GetTargetTable<Product>();

            var scanOps = new ScanOperationConfig();

            //if (!string.IsNullOrEmpty(paginationToken))
            //{
            //    scanOps.PaginationToken = paginationToken;
            //}

            // returns the set of Document objects for the supplied ScanOptions
            var results = table.Scan(scanOps);
            List<Document> productsData = await results.GetNextSetAsync();
            IEnumerable<Product> products = _dynamoDbContext.FromDocuments<Product>(productsData);

            _logger.LogInformation("Sending output from ProductsController::Get() request.");

            return Ok(products);
        }

    }
}