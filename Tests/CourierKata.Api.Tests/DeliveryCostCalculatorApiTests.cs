using System;
using System.Collections.Generic;
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

        public DeliveryCostCalculatorApiTests()
        {
            this.sut = new DeliveryCostCalculatorApi();
        }

        [Fact]
        public void ShouldReturnParcelCosts()
        {
            var order = new OrderDto
            {
                Parcels = new List<ParcelDto>
                {
                    new ParcelDto{Height = 4, Width = 4},
                    new ParcelDto{Height = 20, Width = 25},
                    new ParcelDto{Height = 20, Width = 25}
                }
            };

            var result = this.sut.CalculateCost(order);

            Assert.Equal(3, result.Items[0].Cost);
            Assert.Equal(8, result.Items[1].Cost);
            Assert.Equal(8, result.Items[2].Cost);
        }

        [Fact]
        public void ShouldReturnParcelTypes()
        {
            var order = new OrderDto
            {
                Parcels = new List<ParcelDto>
                {
                    new ParcelDto{Height = 4, Width = 4},
                    new ParcelDto{Height = 20, Width = 25},
                    new ParcelDto{Height = 20, Width = 25}
                }
            };

            var result = this.sut.CalculateCost(order);

            Assert.Equal("SmallParcel", result.Items[0].Type);
            Assert.Equal("MediumParcel", result.Items[1].Type);
            Assert.Equal("MediumParcel", result.Items[2].Type);
        }

        [Fact]
        public void ShouldReturnTotalCost()
        {
            var order = new OrderDto
            {
                Parcels = new List<ParcelDto>
                {
                    new ParcelDto{Height = 4, Width = 4},
                    new ParcelDto{Height = 20, Width = 25},
                    new ParcelDto{Height = 20, Width = 25}
                }
            };

            var result = this.sut.CalculateCost(order);

            Assert.Equal(19, result.TotalCost);
        }
    }
}

