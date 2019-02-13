using System;
using System.Collections.Generic;
using CourierKata.Api;
using CourierKata.Domain;

namespace CourierKata.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var parcelDelivCalcService = new ParcelDeliveryCostCalculatorService();
            var api = new DeliveryCostCalculatorApi(parcelDelivCalcService);

            var order = new OrderDto
            {
                Parcels = new List<ParcelDto>
                {
                    new ParcelDto{Height = 4, Width = 4},
                    new ParcelDto{Height = 20, Width = 25},
                    new ParcelDto{Height = 20, Width = 25}
                }
            };

            var output = api.CalculateCost(order);

            foreach (var item in output.Items)
            {
                Console.WriteLine($"Item:{item.Type}, Cost:${item.Cost}");
            }

            Console.WriteLine($"Total:${output.TotalCost}");
        }
    }
}
