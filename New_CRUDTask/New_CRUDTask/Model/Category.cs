using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace New_CRUDTask.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        [JsonIgnore]
        //one to many
        public ICollection<Product>? Products { get; set; }

    }
}