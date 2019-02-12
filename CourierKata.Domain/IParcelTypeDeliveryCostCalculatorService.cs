namespace CourierKata.Domain
{
    public interface IParcelDeliveryCostCalculatorService
    {
        decimal CalculateDeliveryCost(ParcelType parcelSize);
    }
}