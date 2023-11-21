using CoddingChallenge.DataBase;
using CoddingChallenge.Entities;

namespace CoddingChallenge.Services
{
    public class OrderService : IOrderService { 

        private readonly ChallengeContext _context;
    public OrderService()
    {
        _context=new ChallengeContext();
    }
    
        public List<Order> GetOrders()
        {
            try
            {
                return _context.orders.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Order GetOrdersByProductId(int ProductId)
        {
            try
            {
                return _context.orders.SingleOrDefault(o => o.ProductId == ProductId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PlaceOrder(Order order)
        {
            try
            {
                _context.orders.Add(order);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
