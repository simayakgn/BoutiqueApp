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


    }
}
