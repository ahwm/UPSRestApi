using RestSharp;
using UPSRestApi.Utilities.Internal;
using UPSRestApi.Utilities.Internal.Extensions;

namespace UPSRestApi.Http {
  internal sealed class Request {
    /// <summary>
    ///   Optional query string parameters.
    /// </summary>
    public Dictionary<string, object> AdditionQueryParameters { get => _additionQueryStringParameters ?? new Dictionary<string, object>(); }
    private readonly Dictionary<string, object>? _additionQueryStringParameters;

    /// <summary>
    ///   Optional header parameters.
    /// </summary>
    public Dictionary<string, object> HeaderParameters { get => _headerParameters ?? new Dictionary<string, object>(); }
    private readonly Dictionary<string, object>? _headerParameters;

    /// <summary>
    ///   Optional body or query string parameters.
    /// </summary>
    public Dictionary<string, object> Parameters { get => _parameters ?? new Dictionary<string, object>(); }
    private readonly Dictionary<string, object>? _parameters;

    private readonly RestRequest _restRequest;

    public Request(string controller, Common.Enums.ApiVersion verion, string action, Method method,
        Dictionary<string, object>? paramters = null, Dictionary<string, object>? headerParamters = null,
        Dictionary<string, object>? additionQueryParameters = null) {
      _additionQueryStringParameters = additionQueryParameters;
      string endpoint = string.Format("api/{0}/{1}{2}", controller,
                                      (verion.GetEnumMemberValue() is not null ? $"{verion.GetEnumMemberValue()}/" : ""), action);
      _restRequest = new RestRequest(endpoint, method);
      _parameters = paramters;
      _headerParameters = headerParamters;
    }

    public static explicit operator RestRequest(Request request) => request._restRequest;

    /// <summary>
    ///  Build request header and content.
    /// </summary>
    internal void Build() {
      BuildHeaderParamters();
      BuildParamters();
    }

    /// <summary>
    ///   Add optional header parameters to Rest Request's header.
    /// </summary>
    private void BuildHeaderParamters() {
      if (_headerParameters == null) {

        return;
      }

      foreach (KeyValuePair<string, object> pair in this.HeaderParameters) {
        if (pair.Value == null) {

          continue;
        }

        _restRequest.AddOrUpdateParameter(pair.Key, pair.Value, ParameterType.HttpHeader);
      }
    }

    /// <summary>
    ///   Build request content from paramters
    /// </summary>
    internal void BuildParamters() {
      switch (_restRequest.Method) {
        case Method.Get:
        case Method.Delete:
          BuildQueryParamters();
          break;
        case Method.Post:
        case Method.Patch:
        case Method.Put:
          BuildAdditionQueryParamters();
          BuildBodyParameters();
          break;
        case Method.Head:
        case Method.Options:
        case Method.Merge:
        case Method.Copy:
        case Method.Search:
        default:
          break;
      }
    }

    /// <summary>
    ///   Add addition parameters to RestSharp query string.
    /// </summary>
    private void BuildAdditionQueryParamters() {
      foreach (KeyValuePair<string, object> pair in AdditionQueryParameters) {
        if (pair.Value == null) {

          continue;
        }
        _restRequest.AddParameter(pair.Key, pair.Value, ParameterType.QueryString);
      }
    }

    /// <summary>
    ///   Add parameters to RestSharp query string.
    /// </summary>
    private void BuildQueryParamters() {
      foreach (KeyValuePair<string, object> pair in Parameters) {
        if (pair.Value == null) {

          continue;
        }
        _restRequest.AddParameter(pair.Key, pair.Value, ParameterType.QueryString);
      }
    }

    /// <summary>
    ///  Add parameters to RestSharp body request.
    /// </summary>
    private void BuildBodyParameters() {
      string body = JsonSerialization.ConvertObjectToJson(Parameters);
      _restRequest.AddJsonBody(body);
    }


  }
}
