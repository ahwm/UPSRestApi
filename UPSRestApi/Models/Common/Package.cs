using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Models.Common {
  /// <summary>
  ///   Package Information
  /// </summary>
  public class Package {
    /// <summary>
    ///   Chemical Record Information. Max allow list is 3
    /// </summary>
    [JsonProperty("ChemicalRecord")]
    public List<ChemicalRecord> ChemicalRecords { get; set; }

    /// <summary>
    ///   The emergency information, contact name and/or contract number, required to be communicated 
    ///   when a call is placed to the EmergencyPhone.
    ///   The information is required if there is a value in the EmergencyPhone field above and the 
    ///   shipment is with a US50 or PR origin and/or destination and the RegulationSet is IATA.
    /// </summary>
    public string? EmergencyContact { get; set; }

    /// <summary>
    ///  24 Hour Emergency Phone Number of the shipper.
    ///  For numbers within the U.S., the layout is 1, area code, 7-digit
    ///  number.For all other countries or territories the layout is country or
    ///  territory code, area code, number.
    ///  The Emergency Phone Number can only include the following allowable characters
    ///  “period “.”, dash “-“, plus sign “+” and conventional parentheses “(“ 
    ///  and “)”, “EXT or OPT”.
    ///  
    ///  Required when(TDG regulation set and CommodityRegulatedLevelCode = FR)
    /// </summary>
    public string? EmergencyPhone { get; set; }

    /// <summary>
    ///   Presence/Absence Indicator. Any value is ignored.Presence indicates that shipment is over pack.
    /// </summary>
    public string? OverPackedIndicator { get; set; }

    /// <summary>
    ///   Identifies the package containing Dangerous Goods
    /// </summary>
    public string PackageIdentifier { get; set; }

    /// <summary>
    ///   Regulated Commodity Transport Package Score Quantity.
    /// </summary>
    public string? PackagePoints { get; set; }

    /// <summary>
    ///    Package weight information.
    /// </summary>
    public PackageWeight PackageWeight { get; set; }

    /// <summary>
    /// This is required when a HazMat shipment specifies 
    /// AllPackedInOneIndicator and the regulation set for that shipment is IATA.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]  
    public CommonEnums.QValue? QValue { get; set; }

    /// <summary>
    ///   The packages tracking number.
    /// </summary>
    public string? TrackingNumber { get; set; }

    /// <summary>
    ///   The method of transport by which a shipment is approved to move and the regulations associated with that method. 
    ///   Only required when the CommodityRegulatedLevelCode is FR or LQ.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.TransportationMode? TransportationMode { get; set; }

    /// <summary>
    ///   Indicator to specify that a Dangerous Goods package is voided.
    /// </summary>
    public string? VoidIndicator { get; set; }

    public Package() {
      this.ChemicalRecords = new List<ChemicalRecord>();
    }
  }
}
