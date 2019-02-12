namespace CourierKata.Domain
{
    public class DeliveryCost
    {
        public DeliveryCost(ParcelSize size, decimal cost)
        {
            this.ParcelSize = size;
            this.Cost = cost;
        }

        public ParcelSize ParcelSize { get; }
        public decimal Cost { get; }
    }
}