using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService :ServiceBase, IService<Customer, CustomerModel>
    {
        public CustomerService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Customer record)
        {
            throw new NotImplementedException();
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CustomerModel> Query()
        {
            return _db.Customers.OrderBy(o => o.Name).ThenBy(o => o.Surname).Select(o=> new CustomerModel() { Record=o });
        }

        public ServiceBase Update(Customer record)
        {
            throw new NotImplementedException();
        }
    }
}
