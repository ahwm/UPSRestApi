using System.Data;
using System.Reflection;
using UPSRestApi.Common;
using UPSRestApi.Http;
using UPSRestApi.Services;
using static UPSRestApi.Http.ClientConfiguration;

namespace UPSRestApi {
  public class UpsClient : IDisposable {
    private readonly ClientConfiguration _clientConfiguration;

    /// <summary>
    ///   Validates addresses at the street level in the United States and Puerto Rico.
    /// </summary>
    public IAddressService AddressService { get; private set; }

    /// <summary>
    ///   Validate Air, Ground, and International Dangerous Goods shipments are acceptable to UPS. 
    ///   Notify UPS of Dangerous Goods shipments after shipment processing.
    /// </summary>
    public IDangerousGoodService DangerousGoodService { get; private set; }

    /// <summary>
    ///   Track status of a shipment, delivery , time, and the latest transit scan.
    /// </summary>
    public ITrackService TrackService { get; private set; }

    private bool _isDisposed = false;

    /// <summary>
    ///   Access UPS API Catalog.
    /// </summary>
    /// <param name="apiKey">Bearer token returned from UPS Authorization API.</param>
    /// <param name="envinronment">API Envinronment</param>
    /// <exception cref="NoNullAllowedException"></exception>
    public UpsClient(string apiKey, Enums.Environment envinronment = Enums.Environment.Production) {
      _clientConfiguration = new ClientConfiguration(apiKey, envinronment);
      BuildServices();
    }

    /// <summary>
    ///   Instance service object.
    /// </summary>
    protected void BuildServices() {
      AddressService = GetService<AddressService>();
      DangerousGoodService = GetService<DangerousGoodService>();
      TrackService = GetService<TrackService>();
    }

    /// <summary>
    ///   Get a service instance
    /// </summary>
    /// <typeparam name="T">Type of service class to instantiate</typeparam>
    /// <returns>A T-Type instance.</returns>
    protected T GetService<T>() where T : IGenericService {
      ConstructorInfo[] constructorInfo = typeof(T).GetConstructors();
      return (T)constructorInfo[0].Invoke(new object[] { _clientConfiguration });
    }

    public void Dispose() {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private void Dispose(bool displosing) {
      if (_isDisposed) {

        return;
      }

      if (displosing) {

        AddressService.Dispose();
        DangerousGoodService.Dispose();
        TrackService.Dispose();
      }

      _isDisposed = true;
    }
  }
}
