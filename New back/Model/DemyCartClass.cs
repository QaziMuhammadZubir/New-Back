using System.ComponentModel.DataAnnotations;

namespace New_back.Model
{
    public class DemyCartClass
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least one")]
        public int Quantity { get; set; }
        public string size { get; set; }
        public string ImageNames { get; set; }
        public int Uid { get; set; }
    }
}
