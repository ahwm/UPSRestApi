using UPSRestApi.Models.Common;

namespace UPSRestApi.Models.Dto.DangerousGoods.ChemicalReferenceData {
  public interface IChemicalReferenceDataRequest {
    /// <summary>
    ///   This is the ID number (UN/NA/ID) for the specified commodity. UN/NA/ID Identification Number 
    ///   assigned to the specified regulated good. (Include the UN/NA/ID as part of the entry).
    ///   Details at <see href="https://www.ups.com/us/en/support/shipping-support/shipping-special-care-regulated-items/hazardous-materials-guide/hazardous-material-service-definition/dangerous-goods-chemical-tables.page"/> UPS Chemical Table.
    /// </summary>
    string IDNumber { get; set; }

    /// <summary>
    ///   The Proper Shipping Name assigned by ADR, CFR or IATA.
    ///   Details at <see href="https://www.ups.com/us/en/support/shipping-support/shipping-special-care-regulated-items/hazardous-materials-guide/hazardous-material-service-definition/dangerous-goods-chemical-tables.page"/> UPS Chemical Table.
    /// </summary>
    string ProperShippingName { get; set; }

    /// <summary>
    ///   Contains Chemical Reference Data request criteria components.
    /// </summary>
    RequestOptions? Request { get; set; }

    /// <summary>
    ///   Shipper’s six digit and character account number. This is same account number present in the request that is played back in response.
    /// </summary>
    string ShipperNumber { get; set; }
  }

  public class ChemicalReferenceDataRequest : IChemicalReferenceDataRequest {
    /// <inheritdoc/>
    public string? IDNumber { get; set; }

    /// <inheritdoc/>
    public string? ProperShippingName { get; set; }

    /// <inheritdoc/>
    public RequestOptions? Request { get; set; }

    /// <inheritdoc/>
    public string ShipperNumber { get; set; }
  }
}
