using InversionOfControlDemo.Interfaces;

namespace InversionOfControlDemo
{
    public class Order : IOrder
    {
        public string ReferenceNumber { get; set; }
        public string Description { get; set; }
        public int Quantiy { get; set; }

        public Order(string description, string referenceNumber, int quantity)
        {
            Description = description;
            ReferenceNumber = referenceNumber;
            Quantiy = quantity;
        }
    }
}