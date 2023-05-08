using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Models.Common {
  /// <summary>
  ///   Delivery times associated with the package.
  /// </summary>
  public class DeliveryTime {
    /// <summary>
    ///   The end time of the window. Only returned with the  Type is EDW, CDW or IDW. Format: HHMMSS – 24 hours Local time.
    /// </summary>
    [JsonProperty("endTime")]
    public string EndTime { get; set; }

    /// <summary>
    ///   The start time, committed time or delivered time Format: HHMMSS – 24 hours Local time.
    /// </summary>
    [JsonProperty("startTime")]
    public string? StartTime { get; set; }

    /// <summary>
    ///   Indicates the type of delivery.
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.DeliveryTimeType Type { get; set; }
  }
}
