using System.Text.Json.Serialization;

namespace Company.Function
{
    public class Customer
    {
        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }

        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; }

        [JsonPropertyName("customerPhone")]
        public string CustomerPhone { get; set; }
    }

}
