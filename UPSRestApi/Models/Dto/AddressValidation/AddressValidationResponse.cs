using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.AddressValidation {
  public interface IAddressValidationResponse : IAbstractResponse {
    AddressClassification AddressClassification { get; set; }

    string? AmbiguousAddressIndicator { get; set; }

    List<AddressKeyFormat> Candidate { get; set; }

    string? NoCandidatesIndicator { get; set; }

    string? ValidAddressIndicator { get; set; }
  }

  public class AddressValidationResponse : AbstractResponse, IAddressValidationResponse {
    public string? ValidAddressIndicator { get; set; }

    public string? AmbiguousAddressIndicator { get; set; }

    public string? NoCandidatesIndicator { get; set; }

    public AddressClassification? AddressClassification { get; set; }


    [JsonConverter(typeof(SingleObjectConverter<AddressKeyFormat>))]
    public List<AddressKeyFormat>? Candidate { get; set; }
  }
}
