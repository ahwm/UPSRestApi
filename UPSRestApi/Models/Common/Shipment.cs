using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Models.Common {
  /// <summary>
  ///  Contains shipment information
  /// </summary>
  public class Shipment {
    /// <summary>
    ///   List Package Information.
    ///   Allow maximum 1000 records.
    /// </summary>
    [JsonProperty("Package")]
    public List<Package> Packages { get; set; }

    /// <summary>
    ///   Date of the On Call Air Pickup. Format is YYYYMMDD
    /// </summary>
    public string? PickupDate { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.QValue QValue { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.RegulationSet RegulationSet { get; set; }

    /// <summary>
    ///   UPS service type.
    /// </summary>
    public Service Service { get; set; }

    /// <summary>
    ///   Ship From address
    /// </summary>
    public Address ShipFromAddress { get; set; }

    /// <summary>
    ///   1Z Number of the first package in the shipment.
    /// </summary>
    public string? ShipmentIdentificationNumber { get; set; }

    /// <summary>
    ///   Shipper’s six digit account number.
    /// </summary>
    public string ShipperNumber { get; set; }

    /// <summary>
    ///   Ship From address
    /// </summary>
    public Address ShipToAddress { get; set; }

    /// <summary>
    ///   The method of transport by which a shipment is approved to move and the regulations associated with that method
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.TransportationMode? TransportationMode { get; set; }

    public Shipment() {
      this.Packages = new List<Package>();
    }

  }
}
