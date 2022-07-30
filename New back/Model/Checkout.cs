using System.ComponentModel.DataAnnotations;

namespace New_back.Model
{
    public class Checkout
    {
        [Key]
        public int C_Id { get; set; }
        public string phone { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public int Uid { get; set; }
    }
}
