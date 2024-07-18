using CarAuctionBE.DTOs;

namespace CarAuctionBE.Models;

public class CommonVehicle : Vehicle
{
  public override VehicleFeesCalculationResult CalculatePriceWithFees()
  {
    var feesCalculator = new Services.FeesCalculator();
    return feesCalculator.CalculateFees(this);
  }
}