using Xunit;
using CarAuctionBE.Services;
using CarAuctionBE.Models;

namespace CarAuctionBE.CarAuctionBE.Tests;
public class FeeCalculatorTests
{
    private readonly FeeCalculator _feeCalculator;

    public FeeCalculatorTests()
    {
        _feeCalculator = new FeeCalculator();
    }

    [Fact]
    public void CalculateFees_CommonVehicle_BasePrice398_ReturnsCorrectFees()
    {
        var vehicle = new CommonVehicle { BasePrice = 398m };

        var result = _feeCalculator.CalculateFees(vehicle);

        Assert.Equal(39.80m, result.BasicBuyerFee);
        Assert.Equal(7.96m, result.SellerSpecialFee);
        Assert.Equal(5m, result.AssociationFee);
        Assert.Equal(100m, result.StorageFee);
        Assert.Equal(550.76m, result.TotalVehiclePrice);
    }

    [Fact]
    public void CalculateFees_CommonVehicle_BasePrice501_ReturnsCorrectFees()
    {
        var vehicle = new CommonVehicle { BasePrice = 501m };

        var result = _feeCalculator.CalculateFees(vehicle);

        Assert.Equal(50m, result.BasicBuyerFee);
        Assert.Equal(10.02m, result.SellerSpecialFee);
        Assert.Equal(10m, result.AssociationFee);
        Assert.Equal(100m, result.StorageFee);
        Assert.Equal(671.02m, result.TotalVehiclePrice);
    }

    [Fact]
    public void CalculateFees_CommonVehicle_BasePrice57_ReturnsCorrectFees()
    {
        var vehicle = new CommonVehicle { BasePrice = 57m };

        var result = _feeCalculator.CalculateFees(vehicle);

        Assert.Equal(10m, result.BasicBuyerFee);
        Assert.Equal(1.14m, result.SellerSpecialFee);
        Assert.Equal(5m, result.AssociationFee);
        Assert.Equal(100m, result.StorageFee);
        Assert.Equal(173.14m, result.TotalVehiclePrice);
    }


    [Fact]
    public void CalculateFees_LuxuryVehicle_BasePrice1800_ReturnsCorrectFees()
    {
        var vehicle = new LuxuryVehicle { BasePrice = 1800m };

        var result = _feeCalculator.CalculateFees(vehicle);

        Assert.Equal(180m, result.BasicBuyerFee);
        Assert.Equal(72m, result.SellerSpecialFee);
        Assert.Equal(15m, result.AssociationFee);
        Assert.Equal(100m, result.StorageFee);
        Assert.Equal(2167m, result.TotalVehiclePrice);
    }

    [Fact]
    public void CalculateFees_LuxuryVehicle_BasePrice1000000_ReturnsCorrectFees()
    {
        var vehicle = new LuxuryVehicle { BasePrice = 1000000m };

        var result = _feeCalculator.CalculateFees(vehicle);

        Assert.Equal(200m, result.BasicBuyerFee);
        Assert.Equal(40000m, result.SellerSpecialFee);
        Assert.Equal(20m, result.AssociationFee);
        Assert.Equal(100m, result.StorageFee);
        Assert.Equal(1040320m, result.TotalVehiclePrice);
    }
}