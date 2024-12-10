using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Products
    {
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Name { get; set; }
        [Required,StringLength(50)]
        public string Description { get; set; }
        [Required]
        public int StockQuantity {  get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }
        public int? CategoryId {  get; set; } // foreign key
        public Category Category { get; set; } //navigational property
        

    }
}