namespace UPSRestApi.Models.Dto.DangerousGoods.ChemicalReferenceData {
  public class ChemicalDetail {
    public string AdditionalShippingInformationRequiredIndicator { get; set; }

    public string? CAToUSShipmentAllowedIndicator { get; set; }

    public string? ChannelTunnelAcceptedIndicator { get; set; }

    public string? ChemicalType { get; set; }

    public string ClassDivisionNumber { get; set; }

    public string HazardousMaterialsDescription { get; set; }

    public string IDNumber { get; set; }

    public string PackagingGroupType { get; set; }

    public string RegulationSet { get; set; }

    public string SpecialPermit { get; set; }

    public string SubRiskClass { get; set; }

    public string TechnicalNameRequiredIndicator { get; set; }

    public string? TransportCategory { get; set; }

    public string? TransportMultiplierQuantity { get; set; }

    public string? TunnelRestrictionCode { get; set; }
  }
}
