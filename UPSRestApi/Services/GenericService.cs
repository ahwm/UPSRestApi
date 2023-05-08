using RestSharp;
using UPSRestApi.Common;
using UPSRestApi.Http;
using UPSRestApi.Utilities.Internal;
using static UPSRestApi.Http.ClientConfiguration;
using UPSRestApi.Exceptions.General;
using UPSRestApi.Exceptions.API;
using RestSharp.Serializers.NewtonsoftJson;
using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;

namespace UPSRestApi.Services {
  public abstract class GenericService : IGenericService {
    private IClientConfiguration _clientConfiguration;
    private bool _isDisposed = false;

    /// <summary>
    ///     Gets the default <see cref="Newtonsoft.Json.JsonSerializerSettings" /> to use for de/serialization.
    /// </summary>
    private static JsonSerializerSettings DefaultJsonSerializerSettings => new() {
      NullValueHandling = NullValueHandling.Ignore,
      MissingMemberHandling = MissingMemberHandling.Ignore,
      DateFormatHandling = DateFormatHandling.IsoDateFormat,
      DateTimeZoneHandling = DateTimeZoneHandling.Utc,
      FloatFormatHandling = FloatFormatHandling.String,
    };

    public GenericService(string apiToken, Enums.Environment envinronment = Enums.Environment.Production) : this(new ClientConfiguration(apiToken, envinronment)) { }

    public GenericService(IClientConfiguration clientConfiguration) {
      _clientConfiguration = clientConfiguration;
    }

    public void Dispose() {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    ///   Execute a HTTP request
    /// </summary>
    /// <typeparam name="T">Type of object to serialize from the RestSharp response.</typeparam>
    /// <param name="request">Request content to execute.</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <param name="allowRestThrowError">Optional allow RestSharp throw an exceptions.</param>
    /// <returns>A RestResponse containing a T-Type object.</returns>
    internal virtual async Task<RestResponse<T>> ExecuteRequest<T>(RestRequest request,
        JsonSerializerSettings? jsonSerializerSettings = null, bool allowRestThrowError = false) {
      IRestClient restClient = GetRestClient(jsonSerializerSettings, allowRestThrowError);
      return await restClient.ExecuteAsync<T>(request);
    }

    /// <summary>
    ///   Execute a HTTP request
    /// </summary>
    /// <param name="request"><see cref="RestRequest"/>Request content to execute.</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <param name="allowRestThrowError">Optional allow RestSharp throw an exceptions.</param>
    /// <returns>A RestResponse.</returns>
    internal virtual async Task<RestResponse> ExecuteRequest(RestRequest request,
        JsonSerializerSettings? jsonSerializerSettings = null, bool allowRestThrowError = false) {
      IRestClient restClient = GetRestClient(jsonSerializerSettings, allowRestThrowError);
      return await restClient.ExecuteAsync(request);
    }

    /// <summary>
    ///  Send a Create request to the API. 
    /// </summary>
    /// <typeparam name="T">Type of object to serialize from the RestSharp response.</typeparam>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the body of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="additionQueryParameters">Optional addition parameters that add to the query string of the request.</param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <returns>An instance of a T-type of object.</returns>
    protected async Task<T> Create<T>(string endpoint, Dictionary<string, object>? parameters = null,
        Dictionary<string, object>? headerParameters = null, Dictionary<string, object>? additionQueryParameters = null,
        string? rootElement = null, JsonSerializerSettings? jsonSerializerSettings = null) where T : class {
      return await Request<T>(Method.Post, endpoint, parameters, headerParameters, additionQueryParameters, rootElement, jsonSerializerSettings);
    }

    /// <summary>
    ///   Send a Create request to the API without a response.
    /// </summary>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the body of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="additionQueryParameters">Optional addition parameters that add to the query string of the request.</param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <returns>N/A</returns>
    protected async Task CreateNoReponse(string endpoint, Dictionary<string, object>? parameters = null,
        Dictionary<string, object>? headerParameters = null, Dictionary<string, object>? additionQueryParameters = null,
        string? rootElement = null, JsonSerializerSettings? jsonSerializerSettings = null) {
      await Request(Method.Post, endpoint, parameters, headerParameters, additionQueryParameters, rootElement, jsonSerializerSettings, true);
    }

    /// <summary>
    ///   Send a delete request to the API.
    /// </summary>
    /// <typeparam name="T">Type of object to serialize from the RestSharp response.</typeparam>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the query string of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <returns>An instance of a T-type of object.</returns>
    protected internal async Task<T> Delete<T>(string endpoint, Dictionary<string, object>? parameters = null,
        Dictionary<string, object>? headerParameters = null, string? rootElement = null,
        JsonSerializerSettings? jsonSerializerSettings = null) where T : class {
      return await Request<T>(Method.Delete, endpoint, parameters, headerParameters, null, rootElement, jsonSerializerSettings);
    }

    /// <summary>
    ///   Send a delete request to the API without a response. 
    ///   Notes: The default all request will be successful even if the API return an error.
    ///     To let the RestSharp catch and throw an error use <paramref name="allowRestThrowError"/> to active the exception.
    /// </summary>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the query string of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <returns>N/A</returns>
    protected internal async Task DeleteNoResponse(string endpoint, Dictionary<string, object>? parameters = null,
        Dictionary<string, object>? headerParameters = null, string? rootElement = null,
        JsonSerializerSettings? jsonSerializerSettings = null) {
      await Request(Method.Delete, endpoint, parameters, headerParameters, null, rootElement, jsonSerializerSettings, true);
    }

    protected virtual void Dispose(bool disposing) {
      if (_isDisposed) {
        
        return;
      }

      _isDisposed = true;
    }

    /// <summary>
    ///   Send a Get request to the API.
    /// </summary>
    /// <typeparam name="T">Type of object to serialize from the RestSharp response.</typeparam>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the query string paramters of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <returns>An instance of a T-type of object.</returns>
    protected internal async Task<T> Get<T>(string endpoint, Dictionary<string, object>? parameters = null,
        Dictionary<string, object>? headerParameters = null, string? rootElement = null,
        JsonSerializerSettings? jsonSerializerSettings = null) where T : class {
      return await Request<T>(Method.Get, endpoint, parameters, headerParameters, null, rootElement, jsonSerializerSettings);
    }

    /// <summary>
    ///   The version of UPS API which is use to generate the API URL.
    /// </summary>
    /// <returns>The <see cref="ApiVersion"/> key and name of the version.</returns>
    protected internal abstract Common.Enums.ApiVersion GetApiVersion();

    /// <summary>
    ///   The service resource of UPS API.
    /// </summary>
    /// <returns>Name of the service resource.</returns>
    protected internal abstract string GetResource();

    /// <summary>
    ///   Make an HTTP request to the UPS API. 
    ///   Notes: The default all request will be successful even if the API return an error.
    ///     To let the RestSharp catch and throw an error use <paramref name="allowRestThrowError"/> to active the exception.
    /// </summary>
    /// <param name="method">HTTP method to send a request.</param>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the body or query string paramters of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="additionQueryParameters">
    ///   Optional addition parameters that add to the query string of the request. Not available for the Get and Delete method.
    /// </param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <param name="allowRestThrowError">Optional allow RestSharp throw an exceptions.</param>
    /// <returns>An instance of a T-type of object.</returns>
    protected internal async Task Request(Method method, string endpoint,
        Dictionary<string, object>? parameters = null, Dictionary<string, object>? headerParameters = null,
        Dictionary<string, object>? additionQueryParameters = null, string? rootElement = null,
        JsonSerializerSettings? jsonSerializerSettings = null, bool allowRestThrowError = false) {
      ////Build the request
      RestRequest request = PrepareRequest(new(
          GetResource(), GetApiVersion(), endpoint, method, parameters, headerParameters, additionQueryParameters)
        );

      //Execute the request
      //NOTE: Detault setting RestSharp does not throw exceptions directly.
      await ExecuteRequest(request, jsonSerializerSettings, allowRestThrowError);
    }

    /// <summary>
    ///   Make an HTTP request to the UPS API and deserialize the reponse JSON into an object.
    /// </summary>
    /// <typeparam name="T">Type of object to serialize from the RestSharp response.</typeparam>
    /// <param name="method">HTTP method to send a request.</param>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the body or query string paramters of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="additionQueryParameters">
    ///   Optional addition parameters that add to the query string of the request.. Not available for the Get and Delete method.
    /// </param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <param name="allowRestThrowError">Optional allow RestSharp throw an exceptions.</param>
    /// <returns>An instance of a T-type of object.</returns>
    /// <exception cref="JsonDeserializationError">Throw an error when the body of the response is not in JSON format.</exception>
    protected internal async Task<T> Request<T>(Method method, string endpoint,
        Dictionary<string, object>? parameters = null, Dictionary<string, object>? headerParameters = null,
        Dictionary<string, object>? additionQueryParameters = null, string? rootElement = null,
        JsonSerializerSettings? jsonSerializerSettings = null, bool allowRestThrowError = false) where T : class {
      //Build the request
      RestRequest request = PrepareRequest(new Request(GetResource(), GetApiVersion(), endpoint,
                                                       method, parameters, headerParameters, additionQueryParameters));

      //Execute the request
      RestResponse<T> response = await ExecuteRequest<T>(request, jsonSerializerSettings, allowRestThrowError);
      
      //Check the reponse's status
      if (!response.IsSuccessful) {

        ApiError.FromErrorResponse(response);
      }

      // Get the order of the root elements to use during deserialization
      List<string>? rootElements = null;

      if (!string.IsNullOrWhiteSpace(rootElement)) {

        rootElements = rootElement.Split(',').Select(x => x.Trim()).ToList();
      }

      T responseBody = JsonSerialization.ConvertJsonToObject<T>(response, null, rootElements);

      if (responseBody is null) {

        throw new JsonDeserializationError(typeof(T));
      }

      return responseBody;
    }

    /// <summary>
    ///   Execute an update request.
    /// </summary>
    /// <typeparam name="T">Type of object to serialize from the RestSharp response.</typeparam>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the body of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="additionQueryParameters">Optional addition parameters that add to the query string of the request.</param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <returns>An instance of a T-type of object.</returns>
    protected internal async Task<T> Update<T>(string endpoint, Dictionary<string, object>? parameters = null,
        Dictionary<string, object>? headerParameters = null, Dictionary<string, object>? additionQueryParameters = null,
        string? rootElement = null, JsonSerializerSettings? jsonSerializerSettings = null) where T : class {
      return await Request<T>(Method.Put, endpoint, parameters, headerParameters, additionQueryParameters, rootElement, jsonSerializerSettings);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpoint">The endpoint of the service (Not include base url and version).</param>
    /// <param name="parameters">Optional parameters that add to the body of the request.</param>
    /// <param name="headerParameters">Optional parameters that add to the header of the request.</param>
    /// <param name="additionQueryParameters">Optional addition parameters that add to the query string of the request.</param>
    /// <param name="rootElement">Optional root element for the JSON to begin deserialization at (separate by comma).</param>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <returns>N/A</returns>
    protected internal async Task UpdateNoResponse(string endpoint, Dictionary<string, object>? parameters = null,
        Dictionary<string, object>? headerParameters = null, Dictionary<string, object>? additionQueryParameters = null,
        string? rootElement = null, JsonSerializerSettings? jsonSerializerSettings = null) {
      await Request(Method.Put, endpoint, parameters, headerParameters, additionQueryParameters, rootElement, jsonSerializerSettings, true);
    }

    /// <summary>
    ///   Initialize an instance RestClient.
    /// </summary>
    /// <param name="jsonSerializerSettings">Optional override default JSON serializer settings.</param>
    /// <param name="allowRestThrowError">Optional allow RestSharp throw an exceptions.</param>
    /// <returns>Instance of RestClient.</returns>
    private IRestClient GetRestClient(JsonSerializerSettings? jsonSerializerSettings = null, bool allowRestThrowError = false) {
      RestClientOptions clientOptions = new RestClientOptions() {
        BaseUrl = new Uri(_clientConfiguration.ApiBaseUrl),
        MaxTimeout = _clientConfiguration.ConnectTimeoutMillisecond,
        ThrowOnAnyError = allowRestThrowError
      };

      jsonSerializerSettings = jsonSerializerSettings ?? DefaultJsonSerializerSettings;
      RestClient restClient = new RestClient(clientOptions, configureSerialization: s => s.UseNewtonsoftJson(jsonSerializerSettings));

      return restClient;
    }

    /// <summary>
    ///   Build request header paramters, query string paramters.
    /// </summary>
    /// <param name="request">The <see cref="UPSRestApi.Http.Request"/> object instance to prepare.</param>
    /// <returns>The instance of <see cref="RestRequest"/> to execute.</returns>
    private RestRequest PrepareRequest(Request request) {
      request.Build();

      RestRequest restRequest = (RestRequest)request;
      restRequest.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_clientConfiguration.ApiKey, "Bearer");

      return restRequest;
    }
  }

  public interface IGenericService : IDisposable { }
}
