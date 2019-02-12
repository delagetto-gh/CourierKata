using System;
using Xunit;

namespace CourierKata.Domain.Tests
{
    public class ParcelDeliveryCostCalculatorServiceTests
    {
        private readonly IParcelDeliveryCostCalculatorService sut;

        public ParcelDeliveryCostCalculatorServiceTests()
        {
            this.sut = new ParcelDeliveryCostCalculatorService();
        }

        [Fact]
        public void ShouldClassifyAsSmallSizeParcelGivenAllDimensionsLessThan10cm()
        {
            var parcel = new Parcel(4, 4);

            var result = this.sut.CalculateDeliveryCost(parcel);

            Assert.Equal(ParcelSize.Small, result.ParcelSize);
        }

        [Fact]
        public void ShouldClassifyAsMediumSizeParcelGivenAllDimensionsLessThan50cm()
        {
            var parcel = new Parcel(20, 20);

            var result = this.sut.CalculateDeliveryCost(parcel);

            Assert.Equal(ParcelSize.Medium, result.ParcelSize);
        }

        [Fact]
        public void ShouldClassifyAsLargeSizeParcelGivenAllDimensionsLessThan100cm()
        {
            var parcel = new Parcel(50, 45);

            var result = this.sut.CalculateDeliveryCost(parcel);

            Assert.Equal(ParcelSize.Large, result.ParcelSize);
        }

        [Fact]
        public void ShouldClassifyAsXLSizeParcelGivenAnyDimensionsGreaterThan100cm()
        {
            var parcel = new Parcel(120, 10);

            var result = this.sut.CalculateDeliveryCost(parcel);

            Assert.Equal(ParcelSize.XL, result.ParcelSize);
        }

        [Fact]
        public void ShouldCalculate3DollarDeliveryCostForSmallSizeParcel()
        {
            var parcel = new Parcel(4, 4);

            var result = this.sut.CalculateDeliveryCost(parcel);

            Assert.Equal(3, result.Cost);
        }

        [Fact]
        public void ShouldCalculate8DollarDeliveryCostForMediumSizeParcel()
        {
            var parcel = new Parcel(20, 20);

            var result = this.sut.CalculateDeliveryCost(parcel);

            Assert.Equal(8, result.Cost);
        }

        [Fact]
        public void ShouldCalculate15DollarDeliveryCostForLargeSizeParcel()
        {
            var parcel = new Parcel(50, 45);

            var result = this.sut.CalculateDeliveryCost(parcel);

            Assert.Equal(15, result.Cost);
        }

        [Fact]
        public void ShouldCalculate25DollarDeliveryCostForXLSizeParcel()
        {
            var parcel = new Parcel(120, 10);

            var result = this.sut.CalculateDeliveryCost(parcel);

            Assert.Equal(25, result.Cost);
        }
    }
}
