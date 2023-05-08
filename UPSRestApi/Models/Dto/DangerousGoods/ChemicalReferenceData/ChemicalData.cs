using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.DangerousGoods.ChemicalReferenceData {
  public class ChemicalData {
    public ChemicalDetail ChemicalDetail { get; set; }

    [JsonConverter(typeof(SingleObjectConverter<PackageQuantityLimitDetail>))]
    public List<PackageQuantityLimitDetail>? PackageQuantityLimitDetail { get; set; }

    public ProperShippingNameDetail ProperShippingNameDetail { get; set; }
  }
}
