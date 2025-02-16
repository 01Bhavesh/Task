using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace New_CRUDTask.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Gmail { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
        [JsonIgnore]
        //one to many
        public ICollection<Order>? Orders { get; set; }

    }
}
