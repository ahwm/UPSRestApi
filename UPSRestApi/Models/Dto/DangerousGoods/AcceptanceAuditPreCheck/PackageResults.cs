using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.DangerousGoods.AcceptanceAuditPreCheck {
  public class PackageResults {
    public string? AccessibleIndicator { get; set; }

    [JsonConverter(typeof(SingleObjectConverter<ChemicalRecordResults>))]
    public List<ChemicalRecordResults>? ChemicalRecordResults { get; set; }

    public string? EuropeBUIndicator { get; set; }

    public string PackageIdentifier { get; set; }
  }
}
