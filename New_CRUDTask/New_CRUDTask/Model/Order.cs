using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace New_CRUDTask.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        //many to one 
        public User? Users { get; set; }
        [JsonIgnore]
        //many to many
        public ICollection<ProductOrder>? ProductOrders { get; set; }

    }
}