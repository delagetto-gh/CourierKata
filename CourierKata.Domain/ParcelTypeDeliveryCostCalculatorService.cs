using System;
using System.Collections.Generic;

namespace CourierKata.Domain
{
    public class ParcelDeliveryCostCalculatorService : IParcelDeliveryCostCalculatorService
    {
        private readonly Dictionary<ParcelType, decimal> sizeMap;

        public ParcelTypeDeliveryCostCalculatorService()
        {
            this.sizeMap = new Dictionary<ParcelType, decimal>
            {
                [ParcelType.Small] = 3,
                [ParcelType.Medium] = 8,
                [ParcelType.Large] = 15,
                [ParcelType.XL] = 25,
            };
        }

        public DeliveryCost CalculateDeliveryCost(Parcel parcel)
        {
            if (this.sizeMap.ContainsKey(parcelSize) && this.
                return this.sizeMap[parcelSize];

            

            throw new NotImplementedException();
        }
    }
}