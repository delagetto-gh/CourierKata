namespace CourierKata.Api
{
    public interface IDeliveryCostCalculatorApi
    {
        DeliveryCostBillDto CalculateCost(OrderDto order);
    }
}