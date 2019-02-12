namespace CourierKata.Domain
{
    public interface IParcelDeliveryCostCalculatorService
    {
        DeliveryCost CalculateDeliveryCost(Parcel parcel);
    }
}