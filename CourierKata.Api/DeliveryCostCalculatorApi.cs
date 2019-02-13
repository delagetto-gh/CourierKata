using System.Linq;
using CourierKata.Domain;

namespace CourierKata.Api
{
    public class DeliveryCostCalculatorApi : IDeliveryCostCalculatorApi
    {
        private readonly IParcelDeliveryCostCalculatorService delCostSvc;

        public DeliveryCostCalculatorApi(IParcelDeliveryCostCalculatorService delCostSvc)
        {
            this.delCostSvc = delCostSvc;
        }

        public DeliveryCostBillDto CalculateCost(OrderDto order)
        {
            var deliveryCostDto = new DeliveryCostBillDto();

            var parcels = order.Parcels.Select(o => new Parcel(o.Height, o.Width));

            foreach (var parcel in parcels)
            {
                var cost = this.delCostSvc.CalculateDeliveryCost(parcel);

                var item = new ItemDto
                {
                    Cost = cost.Cost,
                    Type = cost.ParcelSize.ToString()
                };

                deliveryCostDto.Items.Add(item);

                deliveryCostDto.TotalCost += item.Cost;
            }

            return deliveryCostDto;
        }
    }
}