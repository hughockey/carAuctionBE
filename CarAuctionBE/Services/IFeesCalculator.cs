using CarAuctionBE.DTOs;
using CarAuctionBE.Models;

namespace CarAuctionBE.Services;
public interface IFeesCalculator
{
  VehicleFeesCalculationResult CalculateFees(Vehicle vehicle);
}