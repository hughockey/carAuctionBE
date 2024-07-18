using System.ComponentModel.DataAnnotations;
using CarAuctionBE.DTOs;

namespace CarAuctionBE.Models;

public abstract class Vehicle
{
  [Required]
  public decimal BasePrice { get; set; }
  public abstract VehicleFeesCalculationResult CalculatePriceWithFees();
}