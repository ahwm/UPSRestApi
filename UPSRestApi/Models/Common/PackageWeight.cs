using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Common {
  public class PackageWeight {
    [JsonConverter(typeof(FormatNumbersAsTextConverter<double>))]
    public double Weight { get; set; }

    /// <summary>
    ///   Package weight unit of measurement information.
    /// </summary>
    [JsonProperty("UnitOfMeasurement")]
    public UnitOfMeasurement UOM { get; set; }

    public PackageWeight() {
      this.UOM = new UnitOfMeasurement();
    }

    public PackageWeight(double weight, UnitOfMeasurement uOM = null) {
      Weight = weight;
      UOM = uOM ?? new UnitOfMeasurement();
    }


  }
}
