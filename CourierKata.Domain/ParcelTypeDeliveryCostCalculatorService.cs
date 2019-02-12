using System;
using System.Collections.Generic;

namespace CourierKata.Domain
{
    public class ParcelDeliveryCostCalculatorService : IParcelDeliveryCostCalculatorService
    {
        private readonly List<Func<Dimension, DeliveryCost>> sizeMap;

        public ParcelDeliveryCostCalculatorService()
        {
            this.sizeMap = new List<Func<Dimension, DeliveryCost>>
            {
                {p => p.Height + p.Width < 10 ? new DeliveryCost(ParcelSize.Small, 3) : null},
                {p => p.Height + p.Width < 50 ? new DeliveryCost(ParcelSize.Medium, 8) : null},
                {p => p.Height + p.Width < 100 ? new DeliveryCost(ParcelSize.Large, 15) : null},
                {p => p.Height > 100 ||  p.Width > 100  ? new DeliveryCost(ParcelSize.Xl, 25) : null},
            };
        }

        public DeliveryCost CalculateDeliveryCost(Parcel parcel)
        {
            foreach (var map in sizeMap)
            {
                if (map(parcel.Dimension) != null)
                    return map(parcel.Dimension);
            }

            throw new NotImplementedException();
        }
    }
}