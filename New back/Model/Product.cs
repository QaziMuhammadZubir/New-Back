using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace New_back.Model
{
    public class Product
    {

        [Key]
        public int p_Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string price { get; set; }

        public CategoryType CategoryType { get; set; }
        public string description { get; set; }
        public string ImageNames { get; set; }
        [NotMapped] public string ImageBase64 { get; set; }
    }

    public enum CategoryType
    {
        Men, Women, Child
    }




    /*class c1
    {
        public int id { get; set; }
        public int name { get; set; }
        public List<c2> cdlist;
    }

    class c2
    {
        public int id { get; set; }
        public int name { get; set; }
        public List<c1> c1list;
    }*/

}
