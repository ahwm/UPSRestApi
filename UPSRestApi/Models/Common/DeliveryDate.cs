using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Models.Common {
  /// <summary>
  ///    Delivery date details associated with the package
  /// </summary>
  public class DeliveryDate {
    /// <summary>
    ///   Date of the transaction.
    /// </summary>
    [JsonProperty("date")]
    public string Date { get; set; }

    /// <summary>
    ///   Delivery Date Type.
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.DeliveryDateType Type { get; set; }
  }
}
