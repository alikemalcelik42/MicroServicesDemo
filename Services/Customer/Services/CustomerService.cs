using Infrastructure;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        List<Customer> _customerList;

        public CustomerService()
        {
            _customerList = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Demir",
                    BornDate = new DateTime(2000, 4, 2)
                }
            };
        }

        public void Add(Customer customer)
        {
            _customerList.Add(customer);
        }

        public void Delete(Customer customer)
        {
            var deletedCustomer = _customerList.FirstOrDefault(c => c.Id == customer.Id);
            _customerList.Remove(deletedCustomer);
        }

        public List<Customer> GetAll()
        {
            return _customerList;
        }

        public Customer GetById(int id)
        {
            return _customerList.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Customer customer)
        {
            var updatedCustomer = _customerList.FirstOrDefault(c => c.Id == customer.Id);

            updatedCustomer.FirstName = customer.FirstName;
            updatedCustomer.LastName = customer.LastName;
            updatedCustomer.BornDate = customer.BornDate;
        }
    }
}
