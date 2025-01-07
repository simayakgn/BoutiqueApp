
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BLL.DAL
{
    public class Category
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public int? ProductId { get; set; }
        [Required]
        public int? displayOrder {  get; set; }  

        //Navigation property of 1 to many relationship
        public List<Products> Products { get; set; } = new List<Products>(); // Navigation property
       
        
    }
}
