using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeteyPepperoni.Domain
{
    public class OrderManager
    {
        public static void AddCustomer(DTO.OrderDetails customer)
        {
            //calling persistence layer, SOP
            Persistence.OrderRepository.AddCustomer(customer);
        }
    }
}
