using CarAuctionBE.DTOs;

namespace CarAuctionBE.Models;

public class CommonVehicle : Vehicle
{
  public override VehicleFeesCalculationResult CalculatePriceWithFees()
  {
    var feeCalculator = new Services.FeeCalculator();
    return feeCalculator.CalculateFees(this);
  }
}