using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UPSRestApi.Common;

namespace UPSRestApi.Models.Dto.AddressValidation {
  public class AddressClassification {
    [JsonConverter(typeof(StringEnumConverter))]
    public Enums.AddressClassification? Code { get; set; }

    public string? Description { get; set; }
  }
}
