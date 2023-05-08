using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Models.Common {
  public class UnitOfMeasurement {
    /// <summary>
    ///   The code of unit of measurement
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.WeightUnitOfMeasurement Code { get; set; }

    /// <summary>
    ///   Description of the unit of measurement.
    /// </summary>
    public string? Description { get; set; }

    public UnitOfMeasurement(CommonEnums.WeightUnitOfMeasurement code = CommonEnums.WeightUnitOfMeasurement.LBS, string description = null) {
      Code = code;
      Description = description;
    }
  }
}
