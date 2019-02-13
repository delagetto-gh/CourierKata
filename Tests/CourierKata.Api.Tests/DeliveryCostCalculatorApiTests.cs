using System;
using System.Collections.Generic;
using CourierKata.Domain;
using Moq;
using Xunit;

namespace CourierKata.Api.Tests
{
    /*
    "Output should be a collection of items with their individual cost and type, as well as
    total cost
     */
    public class DeliveryCostCalculatorApiTests
    {
        private readonly IDeliveryCostCalculatorApi sut;

        private readonly Mock<IParcelDeliveryCostCalculatorService> mockDelCostSvc;

        public DeliveryCostCalculatorApiTests()
        {
            this.mockDelCostSvc = new Mock<IParcelDeliveryCostCalculatorService>();

            this.sut = new DeliveryCostCalculatorApi(this.mockDelCostSvc.Object);
        }

        [Fact]
        public void ShouldReturnParcelCosts()
        {
            var orderParcels = new List<ParcelDto>
            {
                new ParcelDto{Height = 4, Width = 4},
                new ParcelDto{Height = 20, Width = 25},
                new ParcelDto{Height = 20, Width = 25}
            };

            var order = new OrderDto
            {
                Parcels = orderParcels
            };

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[0].Height, orderParcels[0].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Small, 3));

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[1].Height, orderParcels[1].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Medium, 8));

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[2].Height, orderParcels[2].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Medium, 8));


            var result = this.sut.CalculateCost(order);

            Assert.Equal(3, result.Items[0].Cost);
            Assert.Equal(8, result.Items[1].Cost);
            Assert.Equal(8, result.Items[2].Cost);
        }

        [Fact]
        public void ShouldReturnParcelTypes()
        {
            var orderParcels = new List<ParcelDto>
            {
                new ParcelDto{Height = 4, Width = 4},
                new ParcelDto{Height = 20, Width = 25},
                new ParcelDto{Height = 20, Width = 25}
            };

            var order = new OrderDto
            {
                Parcels = orderParcels
            };

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[0].Height, orderParcels[0].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Small, 3));

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[1].Height, orderParcels[1].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Medium, 8));

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[2].Height, orderParcels[2].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Medium, 8));

            var result = this.sut.CalculateCost(order);

            Assert.Equal("Small", result.Items[0].Type);
            Assert.Equal("Medium", result.Items[1].Type);
            Assert.Equal("Medium", result.Items[2].Type);
        }

        [Fact]
        public void ShouldReturnTotalCost()
        {
            var orderParcels = new List<ParcelDto>
            {
                new ParcelDto{Height = 4, Width = 4},
                new ParcelDto{Height = 20, Width = 25},
                new ParcelDto{Height = 20, Width = 25}
            };

            var order = new OrderDto
            {
                Parcels = orderParcels
            };

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[0].Height, orderParcels[0].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Small, 3));

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[1].Height, orderParcels[1].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Medium, 8));

            this.mockDelCostSvc.Setup(o => o.CalculateDeliveryCost(new Parcel(orderParcels[2].Height, orderParcels[2].Width)))
                                .Returns(new DeliveryCost(ParcelSize.Medium, 8));

            var result = this.sut.CalculateCost(order);

            Assert.Equal(19, result.TotalCost);
        }
    }
}

