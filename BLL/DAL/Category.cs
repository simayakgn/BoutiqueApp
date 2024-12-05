
using System.ComponentModel.DataAnnotations;



namespace BLL.DAL
{
    public class Category
    {
        public object displayOrder;

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation property of 1 to many relationship
        public List<Products> Products { get; set; } = new List<Products>(); // Navigation property
       
        
    }
}
