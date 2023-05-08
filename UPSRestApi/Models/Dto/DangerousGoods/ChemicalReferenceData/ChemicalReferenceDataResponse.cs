using Microsoft.VisualBasic;
using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.DangerousGoods.ChemicalReferenceData {
  public interface IChemicalReferenceDataResponse : IAbstractResponse {
    /// <summary>
    ///    Chemical Data information.
        /// </summary>
        List<ChemicalData>? ChemicalData { get; set; }

    /// <summary>
    ///   6 digit numbers.
    /// </summary>
    string ShipperNumber { get; set; }
  }

  public class ChemicalReferenceDataResponse : AbstractResponse, IChemicalReferenceDataResponse {
    /// <inheritdoc/>
    [JsonConverter(typeof(SingleObjectConverter<ChemicalData>))]
    public List<ChemicalData>? ChemicalData { get; set; }

    /// <inheritdoc/>
    public string? ShipperNumber { get; set; }
  }

}
