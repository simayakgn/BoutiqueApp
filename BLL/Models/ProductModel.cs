using BLL.DAL;
using System.ComponentModel;
using System.Globalization;
namespace BLL.Models
{
    public class ProductModel
    {
        public Products Record { get; set; }
        public string Name => Record.Name;

        [DisplayName("Product Description")]
        public string Description => Record.Description;
        
        public int StockQuantity => Record.StockQuantity;

        [DisplayName("Product Price")]
        public string Price => Record.Price.ToString(CultureInfo.GetCultureInfo("en-US"));//currency
               
        [DisplayName("Created Date")]
        public string CreatedDate => !Record.CreatedDate.HasValue ? string.Empty : Record.CreatedDate.Value.ToString("MM/dd/yyyy");

        public string Category => Record.Category?.Name;

        public string Customers => string.Join("<br>",Record.Wishlists?.Select(wl => wl.Customer?.Name + " " + wl.Customer?.Surname));

        [DisplayName("Customers")]
        public List<int> CustomerIds 
        {  
            get => Record.Wishlists?.Select(wl => wl.CustomerId).ToList(); 
            set => Record.Wishlists = value.Select(v => new Wishlist() { CustomerId = v }).ToList(); 
        }
    }
}
