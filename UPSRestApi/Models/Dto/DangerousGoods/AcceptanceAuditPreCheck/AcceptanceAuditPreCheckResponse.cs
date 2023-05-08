using Newtonsoft.Json;
using UPSRestApi.Common;
using UPSRestApi.Models.Common;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.DangerousGoods.AcceptanceAuditPreCheck {
  public interface IAcceptanceAuditPreCheckResponse : IAbstractResponse {
    List<PackageResults> PackageResults { get; set; }

    Enums.RegulationSet RegulationSet { get; set; }

    Service Service { get; set; }

    string ShipperNumber { get; set; }
  }

  public class AcceptanceAuditPreCheckResponse : AbstractResponse, IAcceptanceAuditPreCheckResponse {
    [JsonConverter(typeof(SingleObjectConverter<PackageResults>))]
    public List<PackageResults> PackageResults { get; set; }

    public Enums.RegulationSet RegulationSet { get; set; }

    public string ShipperNumber { get; set; }

    public Service Service { get; set; }

  }
}
