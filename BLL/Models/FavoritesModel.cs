using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class FavoritesModel
    {
        public int ProductId {  get; set; }
        public int UserId {  get; set; }

        [DisplayName ("Product Name")]
        public string ProductName {  get; set; }

        [DisplayName("Product Price")]
        public string ProductPrice { get; set; }
    }
}
