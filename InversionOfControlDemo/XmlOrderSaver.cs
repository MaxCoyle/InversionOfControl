namespace InversionOfControlDemo
{
    public class XmlOrderSaver : IOrderSaver
    {
        public bool SaveOrder(Order order)
        {
            return order != null;
        }
    }
}
