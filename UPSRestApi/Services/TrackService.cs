using UPSRestApi.Common;
using UPSRestApi.Http;
using UPSRestApi.Models.Dto.Track;

namespace UPSRestApi.Services {
  public interface ITrackService : IGenericService, IDisposable {
    /// <summary>
    ///   Get Single track API details
    /// </summary>
    /// <param name="transId">An identifier unique to the request</param>
    /// <param name="transactionSrc">Customer provided data. Echoed back in the response if provided.</param>
    /// <param name="trackingNumber">
    ///   The tracking number for which tracking information is requested.
    ///   The number must be between 7 and 34 characters in length.
    /// </param>
    /// <param name="returnSignature">The flag indicates the response needs to include the signature.</param>
    /// <returns></returns>
    Task<TrackResponse> TrackPackage(string transId, string transactionSrc, string trackingNumber, bool returnSignature = false);
  }

  /// <summary>
  ///    The Tracking RESTful API supports Package, Ground Freight, and Air Freight shipments, 
  ///    using the tracking number to track, locate, and verify the arrival of a package.
  /// </summary>
  public class TrackService : GenericService, IDisposable, ITrackService {
    private bool _isDisposed = false;

    public TrackService(IClientConfiguration clientConfiguration) : base(clientConfiguration) { }

    public TrackService(string apiToken, Enums.Environment envinronment = Enums.Environment.Production) :
        base(apiToken, envinronment) { }

    /// <inheritdoc/>
    public async Task<TrackResponse> TrackPackage(string transId, string transactionSrc, string trackingNumber, bool returnSignature = false) {
      Dictionary<string, object> headerParamters = new();
      headerParamters.Add("transId", transId);
      headerParamters.Add("transactionSrc", transactionSrc);

      Dictionary<string, object> queryParameters = new();
      queryParameters.Add("locale", "en_US");
      queryParameters.Add("returnSignature", returnSignature);

      return await Get<TrackResponse>(string.Format("details/{0}", trackingNumber),
                                      queryParameters, headerParamters, rootElement: "trackResponse");
    }

    public void Dispose() {
      GC.SuppressFinalize(this);
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
    protected internal override Enums.ApiVersion GetApiVersion() {
      return Enums.ApiVersion.V1;
    }

    /// <inheritdoc/>
    protected internal override string GetResource() {
      return "track";
    }
  }
}
