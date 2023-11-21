using CoddingChallenge.Entities;

namespace CoddingChallenge.Services
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
        List<Order> GetOrders();
        Order GetOrdersByProductId(int ProductId); 
        
        
    }
}
