using System.Text.Json.Serialization;

namespace Company.Function
{
    public class Order
    {
        [JsonPropertyName("orderId")]
        public string? OrderId { get; set; }

        [JsonPropertyName("item")]
        public string? Item { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }
    }

}
