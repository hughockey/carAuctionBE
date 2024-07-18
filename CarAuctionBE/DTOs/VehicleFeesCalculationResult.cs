namespace CarAuctionBE.DTOs;
  public class VehicleFeesCalculationResult
{
  public decimal BasePrice { get; set; }
  public decimal BasicBuyerFee { get; set; }
  public decimal SellerSpecialFee { get; set; }
  public decimal AssociationFee { get; set; }
  public decimal StorageFee { get; set; }
  public decimal TotalVehiclePrice { get; set; }
}
