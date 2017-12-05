using InversionOfControlDemo.Interfaces;

namespace InversionOfControlDemo
{
    public class OrderService : IOrderService
    {
        private readonly IOrderSaver _orderSaver;

        public OrderService(IOrderSaver orderSaver)
        {
            this._orderSaver = orderSaver;
        }

        public bool AcceptOrder(Order order)
        {
            return _orderSaver.SaveOrder(order);
        }
    }
}