using System.Net;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UPSRestApi.Exceptions.API {
  public class ApiError : BaseException {
    // All constructors for API exceptions are protected, so you cannot directly initialize an instance of the exception class.
    // Instead, you must use the .FromResponse method to retrieve an instance.
    protected ApiError(string code, string message, int? statusCode = null) : base(code, message) {
      this.Code = code;
    }

    internal static void FromErrorResponse(RestResponse response) {
      HttpStatusCode statusCode = response.StatusCode;
      int statusCodeNumber = (int)statusCode;

      string errorMsg = "";
      string errorCode = "";

      object? bodyReponse = JsonConvert.DeserializeObject(response.Content);

      if (bodyReponse != null && (bodyReponse as JObject).ContainsKey("response")) {

        JObject obj = (bodyReponse as JObject);

        if (obj.ContainsKey("response") && obj["response"]?["errors"] != null) {

          errorCode = obj["response"]?["errors"][0]["code"].ToString() ?? "";
          errorMsg = obj["response"]?["errors"][0]["message"].ToString() ?? "";

          ThrowExceptionFromReponse(errorCode, errorMsg, statusCodeNumber);
        } else {
          errorMsg = response.StatusDescription ?? "";
        }
      } else {
        errorMsg = response.StatusDescription ?? "";
      }

      ThrowExceptionFromReponse(errorCode, errorMsg, statusCodeNumber);
    }

    private static IBaseException ThrowExceptionFromReponse(string errorCode, string message, int statusCode) {
      throw statusCode switch {
        400 => throw new General.InvalidRequestError(errorCode, message, statusCode),
        401 => throw new General.UnauthorizedError(errorCode, message),
        404 => throw new General.NotFoundError(errorCode, message),
        405 => throw new General.MethodNotAllowedError(errorCode, message),
        500 => throw new General.InternalServerError(errorCode, message),
        503 => throw new General.ServerError(errorCode, message),
        _ => throw new BaseException(errorCode, message),
      };
    }
  }
}
