using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.DangerousGoods.ChemicalReferenceData {
  public class ProperShippingNameDetail {
    [JsonConverter(typeof(SingleObjectConverter<string>))]
    public List<string>? ProperShippingName { get; set; }

    public ProperShippingNameDetail() {
      ProperShippingName = new List<string>();
    }
  }
}
