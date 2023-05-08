using UPSRestApi.Common;

namespace UPSRestApi.Http {
  public interface IClientConfiguration {
    string ApiBaseUrl { get; }
    Enums.Environment ApiEnvironment { get; set; }
    string ApiKey { get; }
    int ConnectTimeoutMillisecond { get; set; }
    int RequestTimeoutMilliseconds { get; set; }
  }

  /// <summary>
  ///   Provides configuration options for the rest client. Used internally to store API key, username, password and other configuration.
  /// </summary>
  public class ClientConfiguration : IClientConfiguration {
    /// <summary>
    ///   The API base URI test environment.
    /// </summary>
    private const string _defaultTestUrl = "https://wwwcie.ups.com/";

    /// <summary>
    ///   The API base URI production environment.
    /// </summary>
    private const string _defaultProductionUrl = "https://onlinetools.ups.com/";

    /// <summary>
    ///   The connection timeout in milliseconds.
    /// </summary>
    private const int _defaultConnectTimeoutMilliseconds = 30000;

    /// <summary>
    ///   The request timeout in milliseconds.
    /// </summary>
    private const int _defaultRequestTimeoutMilliseconds = 30000;

    /// <summary>
    ///   Get the Api Base Url.
    /// </summary>
    public string ApiBaseUrl { get { return ApiEnvironment == Enums.Environment.Test ? _defaultTestUrl : _defaultProductionUrl; } }

    /// <summary>
    ///   The environment of the API.
    /// </summary>
    public Enums.Environment ApiEnvironment { get; set; } = Enums.Environment.Production;

    /// <summary>
    ///   Get the API key.
    /// </summary>
    public string ApiKey { get; internal set; }

    /// <summary>
    ///   The maximum Api connection timeout.
    /// </summary>
    public int ConnectTimeoutMillisecond {
      get => _connectTimeoutMilliseconds ?? _defaultConnectTimeoutMilliseconds;
      set => _connectTimeoutMilliseconds = value;
    }

    private int? _connectTimeoutMilliseconds;

    /// <summary>
    ///   The maximum Api request timeout.
    /// </summary>
    public int RequestTimeoutMilliseconds {
      get => _requestTimeoutMilliseconds ?? _defaultRequestTimeoutMilliseconds;
      set => _requestTimeoutMilliseconds = value;
    }

    private int? _requestTimeoutMilliseconds;

    public ClientConfiguration(string apiKey, Enums.Environment envinronment = Enums.Environment.Production) {
      ApiKey = apiKey;
      ApiEnvironment = envinronment;
    }
  }
}
