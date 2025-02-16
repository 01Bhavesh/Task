using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace New_CRUDTask.Model
{
    public class ProductOrder
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quntity { get; set; }
        [JsonIgnore]
        public Product? Products { get; set; }
        [JsonIgnore]
        public Order? Orders { get; set; }
    }
}
