using Microsoft.AspNetCore.Mvc;
using CarAuctionBE.Models;
using CarAuctionBE.DTOs;

namespace CarAuctionBE.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuctionController : ControllerBase
{
    [HttpGet("GetTotalVehiclePrice")]
    public ActionResult<VehicleFeesCalculationResult> GetTotalVehiclePrice([FromQuery] decimal basePrice, [FromQuery] string vehicleType)
    {
        try
        {
            Vehicle vehicle = vehicleType.ToLower() switch
            {
                "common" => new CommonVehicle { BasePrice = basePrice },
                "luxury" => new LuxuryVehicle { BasePrice = basePrice },
                _ => throw new ArgumentException("Invalid vehicle type")
            };

            if (basePrice < 0) throw new ArgumentException("Invalid vehicle base price");

            var totalVehiclePriceWithFees = vehicle.CalculatePriceWithFees();
            return Ok(totalVehiclePriceWithFees);
        }
        catch (Exception ex)
        {
            return BadRequest(new ErrorResponse { Message = ex.Message });
        }
    }
}