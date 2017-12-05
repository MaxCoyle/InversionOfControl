namespace InversionOfControlDemo
{
    public class OrderDatabase : IOrderSaver
    {
        public bool SaveOrder(Order order)
        {
            return order != null;
        }
    }
}
