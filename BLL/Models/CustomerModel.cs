using BLL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CustomerModel
    {
        public Customer Record { get; set; }

        public string Name => Record.Name;

        public string Surname => Record.Surname;

        [DisplayName("Customer Name and Surname")]
        public string NameAndSurname => Record.Name + " " + Record.Surname;

        [DisplayName("Customer Phone Number")]
        public string Phone => Record.Phone;

        public string Mail {  get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        
    }
}
