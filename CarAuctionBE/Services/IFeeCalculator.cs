using CarAuctionBE.DTOs;
using CarAuctionBE.Models;

namespace CarAuctionBE.Services;
public interface IFeeCalculator
{
  VehicleFeesCalculationResult CalculateFees(Vehicle vehicle);
}