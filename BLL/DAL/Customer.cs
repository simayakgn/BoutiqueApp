
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }
       

        [Required, StringLength(40)]
        public string Mail { get; set; }

        [Required, StringLength(20)]
        public string Phone { get; set; }

        [Required, StringLength(50)]
        public string Address { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }

        public List<Wishlist> Wishlists { get; set; } = new List<Wishlist>(); //Navigational Property to Wishlist

    }
}
