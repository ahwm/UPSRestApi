using UPSRestApi.Common;
namespace UPSRestApi.Models.Dto.DangerousGoods.AcceptanceAuditPreCheck {
  public class ChemicalRecordResults {
    public string? ADRPoints { get; set; }

    public string? ADRUnits { get; set; }

    public string? ChemicalRecordIdentifier { get; set; }

    public Enums.TransportCategory? TransportCategory { get; set; }

    public string? TunnelRestrictionCode { get; set; }
  }
}
