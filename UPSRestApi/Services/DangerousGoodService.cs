using UPSRestApi.Common;
using UPSRestApi.Http;
using UPSRestApi.Models.Dto.DangerousGoods.AcceptanceAuditPreCheck;
using UPSRestApi.Models.Dto.DangerousGoods.ChemicalReferenceData;
using UPSRestApi.Models.Dto.DangerousGoods.PreNotification;

namespace UPSRestApi.Services {
  public interface IDangerousGoodService : IGenericService, IDisposable {
    /// <summary>
    ///   Audit Pre-check service for dangerous goods utility.
    /// </summary>
    /// <param name="transId">An identifier unique to the request.</param>
    /// <param name="transactionSrc">An identifier of the client/source application that is making the request.</param>
    /// <param name="request">Dangerous Goods Utility Request container for Acceptance Audit Pre-check.</param>
    /// <returns></returns>
    Task<IAcceptanceAuditPreCheckResponse> AcceptanceAuditPreCheck(string transId, string transactionSrc, IAcceptanceAuditPreCheckRequest request);

    /// <summary>
    ///   Chemical Reference Data service for dangerous goods utility.
    /// </summary>
    /// <param name="request">Dangerous Goods Utility Request container for Chemical Reference Data.</param>
    /// <returns></returns>
    Task<IChemicalReferenceDataResponse> ChemicalReferenceData(IChemicalReferenceDataRequest request);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="transId"></param>
    /// <param name="transactionSrc">Customer provided data. Echoed back in the response if provided.</param>
    /// <returns></returns>
    Task<IPreNotificationReponse> PreNotification(string transId, string transactionSrc, IPreNotificationRequest request);
  }

  /// <summary>
  ///   The Dangerous Goods API provides the ability to determine what Dangerous Goods 
  ///   (also known as Hazardous Materials) can be carried by UPS.
  /// </summary>
  public class DangerousGoodService : GenericService, IDangerousGoodService, IDisposable {
    private bool _isDisposed = false;

    public DangerousGoodService(ClientConfiguration clientConfiguration) : base(clientConfiguration) { }

    public DangerousGoodService(string apiKey, Enums.Environment envinronment = Enums.Environment.Production) : base(apiKey, envinronment) { }

    /// <inheritdoc/>
    public async Task<IAcceptanceAuditPreCheckResponse> AcceptanceAuditPreCheck(string transId, string transactionSrc, IAcceptanceAuditPreCheckRequest request) {
      Dictionary<string, object> headerParameters = new() {
        { "transId",transId},
        { "transactionSrc",transactionSrc}
      };

      Dictionary<string, object> requestParameters = new Dictionary<string, object>();
      requestParameters.Add("AcceptanceAuditPreCheckRequest", request);

      return await this.Create<AcceptanceAuditPreCheckResponse>("acceptanceauditprecheck", requestParameters, headerParameters,
                                                                rootElement: "AcceptanceAuditPreCheckResponse");
    }

    /// <inheritdoc/>
    public async Task<IChemicalReferenceDataResponse> ChemicalReferenceData(IChemicalReferenceDataRequest request) {
      Dictionary<string, object> requestParameters = new Dictionary<string, object>();
      requestParameters.Add("AcceptanceAuditPreCheckRequest", request);

      return await this.Create<ChemicalReferenceDataResponse>("chemicalreferencedata",
                                                             new Dictionary<string, object>() { { "ChemicalReferenceDataRequest", request } },
                                                             rootElement: "ChemicalReferenceDataResponse");
    }

    public void Dispose() {
      GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    public async Task<IPreNotificationReponse> PreNotification(string transId, string transactionSrc, IPreNotificationRequest request) {
      return await this.Create<PreNotificationReponse>("prenotification",
                                                       new Dictionary<string, object>() { { "PreNotificationRequest", request } },
                                                       rootElement: "PreNotificationResponse");
    }

    protected virtual void Dispose(bool disposing) {
      if (_isDisposed) {

        return;
      }

      if (disposing) {

        base.Dispose(disposing);
      }

      _isDisposed = true;
    }

    /// <inheritdoc/>
    protected internal override Common.Enums.ApiVersion GetApiVersion() {
      return Common.Enums.ApiVersion.V1;
    }

    /// <inheritdoc/>
    protected internal override string GetResource() {
      return "dangerousgoods";
    }
  }


}
