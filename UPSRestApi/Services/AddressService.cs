using UPSRestApi.Common;
using UPSRestApi.Http;
using UPSRestApi.Models.Common;
using UPSRestApi.Models.Dto.AddressValidation;

namespace UPSRestApi.Services {
  public interface IAddressService : IGenericService, IDisposable {
    /// <summary>
    ///   Classify address type. Valid Values: UnClassified, Commercial ,Residential.
    /// </summary>
    /// <param name="address">Address information.</param>
    /// <param name="regionRequestIndicator">
    ///   If True, either the region element or any combination of Political Division 1, Political Division 2, 
    ///   PostcodePrimaryLow and the PostcodeExtendedLow fields will be recognized for validation in addition 
    ///   to the urbanization element. If False or no indicator, street level address validation is provided.
    /// </param>
    /// <param name="maximumCandidateListSize">
    ///   The maximum number of Candidates to return for this request. 
    ///   If not providex, the default size of 15 is returned.
    ///   Valid values: 0 - 50.
    ///   </param>
    /// <returns></returns>
    Task<AddressValidationResponse> ClassifyAddress(Address address, bool? regionRequestIndicator = false, int? maximumCandidateListSize = 0);

    /// <summary>
    ///   Validate address.
    /// </summary>
    /// <param name="address">Address information.</param>
    /// <param name="regionRequestIndicator">
    ///   If True, either the region element or any combination of Political Division 1, Political Division 2, 
    ///   PostcodePrimaryLow and the PostcodeExtendedLow fields will be recognized for validation in addition 
    ///   to the urbanization element. If False or no indicator, street level address validation is provided.
    /// </param>
    /// <param name="maximumCandidateListSize">
    ///   The maximum number of Candidates to return for this request. 
    ///   If not providex, the default size of 15 is returned.
    ///   Valid values: 0 - 50.
    ///   </param>
    /// <returns></returns>
    Task<AddressValidationResponse> ValidateAddress(Address address, bool? regionRequestIndicator = false, int? maximumCandidateListSize = 0);

    /// <summary>
    ///   Validate address and classify the type of address. Valid Values: UnClassified, Commercial ,Residential.
    /// </summary>
    /// <param name="address">Address information.</param>
    /// <param name="regionRequestIndicator">
    ///   If True, either the region element or any combination of Political Division 1, Political Division 2, 
    ///   PostcodePrimaryLow and the PostcodeExtendedLow fields will be recognized for validation in addition 
    ///   to the urbanization element. If False or no indicator, street level address validation is provided.
    /// </param>
    /// <param name="maximumCandidateListSize">
    ///   The maximum number of Candidates to return for this request. 
    ///   If not providex, the default size of 15 is returned.
    ///   Valid values: 0 - 50.
    ///   </param>
    /// <returns></returns>
    Task<AddressValidationResponse> ValidateAndClassyAddress(IAddress address,
                                                             bool? regionRequestIndicator = false, int? maximumCandidateListSize = 0);
  }

  /// <summary>
  ///    Address Validation Street Level API used to check addresses against the United States Postal Service 
  ///    database of valid addresses in the U.S. and Puerto Rico.
  /// </summary>
  public class AddressService : GenericService, IAddressService, IDisposable {

    private const string _rootElements = "XAVResponse";
    private bool _isDisposed = false;

    public AddressService(IClientConfiguration clientConfiguration) : base(clientConfiguration) { }

    public AddressService(string apiToken, Enums.Environment envinronment = Enums.Environment.Production) :
        base(apiToken, envinronment) { }

    public void Dispose() {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    public async Task<AddressValidationResponse> ClassifyAddress(Address address,
                                                                 bool? regionRequestIndicator = false, int? maximumCandidateListSize = 0) {
      Dictionary<string, object> requestParameters = GetRequestParamters(address, regionRequestIndicator);
      Dictionary<string, object> additionQueryParameters = GetAddressAddtionParamters(regionRequestIndicator, maximumCandidateListSize);

      return await this.Create<AddressValidationResponse>("2", requestParameters, 
        additionQueryParameters: additionQueryParameters, rootElement: _rootElements);
    }

    /// <inheritdoc/>
    public async Task<AddressValidationResponse> ValidateAddress(Address address,
                                                                 bool? regionRequestIndicator = false, int? maximumCandidateListSize = 0) {
      Dictionary<string, object> requestParameters = GetRequestParamters(address, regionRequestIndicator);
      Dictionary<string, object> additionQueryParameters = GetAddressAddtionParamters(regionRequestIndicator, maximumCandidateListSize);

      return await this.Create<AddressValidationResponse>("1", requestParameters, 
        additionQueryParameters: additionQueryParameters, rootElement: _rootElements);
    }

    /// <inheritdoc/>
    public async Task<AddressValidationResponse> ValidateAndClassyAddress(
        IAddress address, bool? regionRequestIndicator = false, int? maximumCandidateListSize = 0) {
      Dictionary<string, object> requestParameters = GetRequestParamters(address, regionRequestIndicator);
      Dictionary<string, object> additionQueryParameters = GetAddressAddtionParamters(regionRequestIndicator, maximumCandidateListSize);

      return await this.Create<AddressValidationResponse>("3", requestParameters, 
        additionQueryParameters: additionQueryParameters, rootElement: _rootElements);
    }

    /// <inheritdoc/>
    protected internal override Common.Enums.ApiVersion GetApiVersion() {
      return Common.Enums.ApiVersion.V1;
    }

    /// <inheritdoc/>
    protected internal override string GetResource() {
      return "addressvalidation";
    }

    protected virtual void Dispose(bool disposing) {
      if (_isDisposed) {

        return;
      }

      if(disposing) {

        base.Dispose(disposing);
      }

      _isDisposed = true;
    }

    /// <summary>
    ///   Get the general format of the request body.
    /// </summary>
    /// <param name="address">Address information</param>
    /// <param name="regionRequestIndicator">
    ///   If True, either the region element or any combination of Political Division 1, Political Division 2, 
    ///   PostcodePrimaryLow and the PostcodeExtendedLow fields will be recognized for validation in addition 
    ///   to the urbanization element. If False or no indicator, street level address validation is provided.
    /// </param>
    /// <returns>Dictionary Address Validation with key XAVRequest</returns>
    private Dictionary<string, object> GetRequestParamters(IAddress address, bool? regionRequestIndicator = false) {
      AddressKeyFormat addressKeyFromat = new AddressKeyFormat(address, regionRequestIndicator ?? false);
      Dictionary<string, object> requestParameters = new();
      requestParameters.Add("XAVRequest", new Dictionary<string, object>() { { "AddressKeyFormat", addressKeyFromat } });

      return requestParameters;
    }

    /// <summary>
    ///   Get addition query string from function parameters.
    /// </summary>
    /// <param name="regionRequestIndicator">
    ///   If True, either the region element or any combination of Political Division 1, Political Division 2, 
    ///   PostcodePrimaryLow and the PostcodeExtendedLow fields will be recognized for validation in addition 
    ///   to the urbanization element. If False or no indicator, street level address validation is provided.
    /// </param>
    /// <param name="maximumCandidateListSize">
    ///   The maximum number of Candidates to return for this request. 
    ///   If not providex, the default size of 15 is returned.
    ///   Valid values: 0 - 50.
    /// </param>
    /// <returns></returns>
    private Dictionary<string, object> GetAddressAddtionParamters(bool? regionRequestIndicator, int? maximumCandidateListSize) {
      Dictionary<string, object> parameters = new Dictionary<string, object>();

      if (regionRequestIndicator != null && regionRequestIndicator == true) {

        parameters.Add("regionalrequestindicator", "1");
      }

      if (maximumCandidateListSize != null && maximumCandidateListSize > 1 && maximumCandidateListSize <= 50) {

        parameters.Add("maximumcandidatelistsize", maximumCandidateListSize.ToString());
      }

      return parameters;
    }
  }
}
