using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace New_CRUDTask.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public int? Pirce { get; set; }
        public bool? IsActive { get; set; }
        [JsonIgnore]
        //many to one
        public Category? Categories { get; set; }
        [JsonIgnore]
        //many to many
        public ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
