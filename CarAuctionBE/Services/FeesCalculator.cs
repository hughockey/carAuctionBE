using CarAuctionBE.DTOs;
using CarAuctionBE.Models;

namespace CarAuctionBE.Services;
public class FeesCalculator : IFeesCalculator
{
    public VehicleFeesCalculationResult CalculateFees(Vehicle vehicle)
    {
        decimal basicBuyerFee = 0;
        decimal sellerSpecialFee = 0;
        decimal associationFee = 0;
        const decimal storageFee = 100;

        if (vehicle is CommonVehicle)
        {
            basicBuyerFee = vehicle.BasePrice * 0.10m;
            basicBuyerFee = Math.Clamp(basicBuyerFee, 10, 50);
            sellerSpecialFee = vehicle.BasePrice * 0.02m;
        }
        else if (vehicle is LuxuryVehicle)
        {
            basicBuyerFee = vehicle.BasePrice * 0.10m;
            basicBuyerFee = Math.Clamp(basicBuyerFee, 25, 200);
            sellerSpecialFee = vehicle.BasePrice * 0.04m;
        }

        if (vehicle.BasePrice <= 500)
            associationFee = 5;
        else if (vehicle.BasePrice <= 1000)
            associationFee = 10;
        else if (vehicle.BasePrice <= 3000)
            associationFee = 15;
        else
            associationFee = 20;

        decimal totalVehiclePrice = vehicle.BasePrice + basicBuyerFee + sellerSpecialFee + associationFee + storageFee;

        return new VehicleFeesCalculationResult
        {
            BasePrice = vehicle.BasePrice,
            BasicBuyerFee = basicBuyerFee,
            SellerSpecialFee = sellerSpecialFee,
            AssociationFee = associationFee,
            StorageFee = storageFee,
            TotalVehiclePrice = totalVehiclePrice
        };
    }
}