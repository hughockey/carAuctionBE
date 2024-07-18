using Xunit;
using CarAuctionBE.Services;
using CarAuctionBE.Models;
using CarAuctionBE.Controllers;
using CarAuctionBE.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionBE.CarAuctionBE.Tests;

public class AuctionControllerTests
{
  private readonly AuctionController _controller;

  public AuctionControllerTests()
  {
    _controller = new AuctionController();
  }

  [Fact]
  public void GetTotalPrice_CommonVehicle_ReturnsCorrectResult()
  {
    decimal basePrice = 500m;
    string vehicleType = "common";

    var totalVehiclePriceResult = _controller.GetTotalVehiclePrice(basePrice, vehicleType);
    var okResult = Assert.IsType<OkObjectResult>(totalVehiclePriceResult.Result);
    var value = Assert.IsType<VehicleFeesCalculationResult>(okResult.Value);

    Assert.NotNull(value);
  }

  [Fact]
  public void GetTotalPrice_InvalidBasePrice_ReturnsBadRequest()
  {
    decimal basePrice = -1;
    string vehicleType = "luxury";

    var totalVehiclePriceResult = _controller.GetTotalVehiclePrice(basePrice, vehicleType);

    var badRequestResult = Assert.IsType<BadRequestObjectResult>(totalVehiclePriceResult.Result);
    var messageValue = badRequestResult.Value as ErrorResponse;
    Assert.NotNull(messageValue);
    Assert.Equal("Invalid vehicle base price", messageValue.Message);
  }

  [Fact]
  public void GetTotalPrice_InvalidVehicleType_ReturnsBadRequest()
  {
    decimal basePrice = 500;
    string vehicleType = "invalid";

    var totalVehiclePriceResult = _controller.GetTotalVehiclePrice(basePrice, vehicleType);

    var badRequestResult = Assert.IsType<BadRequestObjectResult>(totalVehiclePriceResult.Result);
    var messageValue = badRequestResult.Value as ErrorResponse;
    Assert.NotNull(messageValue);
    Assert.Equal("Invalid vehicle type", messageValue.Message);
  }
}