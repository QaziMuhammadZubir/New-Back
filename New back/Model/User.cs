using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace New_back.Model
{
    public class User
    {
        [Key]
        public int U_Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string Role { get; set; }
    }

}
