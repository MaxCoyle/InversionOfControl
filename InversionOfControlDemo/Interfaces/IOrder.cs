namespace InversionOfControlDemo.Interfaces
{
    public interface IOrder
    {
        string ReferenceNumber { get; set; }

        string Description { get; set; }

        int Quantiy { get; set; }
    }
}