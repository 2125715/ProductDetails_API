using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProductDetails.Models
{
    public class Productsinfo
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Title is required")]

        public string title { get; set; }

        [Required(ErrorMessage = "Price is required")]

        public int price { get; set; }
        [Required(ErrorMessage = "Description is required")]

        public string description { get; set; }
        [Required(ErrorMessage = "Category is required")]

        public string category { get; set; }
        [Required(ErrorMessage = "Quantity is required")]

        public int  quantity { get; set;}
        [Required(ErrorMessage = "Image is required")]

        public string image { get; set; }
    }
}
