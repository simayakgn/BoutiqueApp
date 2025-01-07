using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Products
    {
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        
        public string Description { get; set; }
        [Required]
        public int StockQuantity {  get; set; }

        [Required]
        public string? Price { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }

        [Required (ErrorMessage ="Category is required!")]
        public int? CategoryId {  get; set; } // foreign key
        public Category Category { get; set; } //navigational property

        public List<Wishlist> Wishlists { get; set; } = new List<Wishlist>(); //Navigational Property to Wishlist


    }
}