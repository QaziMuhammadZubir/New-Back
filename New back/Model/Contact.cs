using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace New_back.Model
{
    public class Contact
    {
        [Key]
        public int co_Id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public string message { get; set; }
    }
}
