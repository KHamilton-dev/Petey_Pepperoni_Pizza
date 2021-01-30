using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeteyPepperoni.Persistence
{
    public class OrderRepository
    {
        public static void AddCustomer(DTO.OrderDetails newOrder)
        {
            //storing order in db
            OrderStorageEntities db = new OrderStorageEntities();
            var dbOrders = db.OrderInformations;

            var storingOrder = new OrderInformation();

            storingOrder.orderID = Guid.NewGuid();
            storingOrder.Name = newOrder.Name;
            storingOrder.Address = newOrder.Address;
            storingOrder.ZipCode = newOrder.ZipCode;
            storingOrder.PaymentMethod = newOrder.PaymentMethod;
            storingOrder.Size = newOrder.Size;
            storingOrder.Crust = newOrder.Crust;
            storingOrder.Sausage = newOrder.Sausage;
            storingOrder.Mushrooms = newOrder.Mushrooms;
            storingOrder.BlackOlives = newOrder.BlackOlives;
            storingOrder.GreenOlives = newOrder.GreenOlives;
            
            try
            {
                dbOrders.Add(storingOrder);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
