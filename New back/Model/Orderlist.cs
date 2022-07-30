using System.ComponentModel.DataAnnotations;
namespace New_back.Model
{
    public class Orderlist
    {
        [Key]
        public int Order_Id { get; set; }
        public int UC_ID { get; set; }
        public string DateTime { get; set; }  
    }
}
