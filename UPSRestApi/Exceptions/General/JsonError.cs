using System.Data;
using System.Globalization;
using UPSRestApi.Common;

namespace UPSRestApi.Exceptions.General {
  public class JsonError : DataException {
    /// <summary>
    ///   Initializes a new instance of the <see cref="JsonError"/> class.
    /// </summary>
    /// <param name="message"></param>
    public JsonError(string message) : base(message) { }
  }

  public class JsonDeserializationError : JsonError {
    /// <summary>
    ///   Initializes a new instance of the <see cref="JsonDeserializationError"/> class.
    /// </summary>
    /// <param name="toType"></param>
    public JsonDeserializationError(Type toType) : base(
        string.Format(CultureInfo.InvariantCulture,
                      Constants.ErrorMessages.JsonDeserializationError, toType.FullName)) {

    }
  }

  public class JsonSerializationError : JsonError {
    /// <summary>
    ///   Initializes a new instance of the <see cref="JsonSerializationError"/> class.
    /// </summary>
    /// <param name="toType"></param>
    public JsonSerializationError(Type toType) : base(
        string.Format(CultureInfo.InvariantCulture,
                      Constants.ErrorMessages.JsonSerializationError, toType.FullName)) {

    }
  }

  public class JsonNoDataError : JsonError {
    /// <summary>
    ///   Initializes a new instance of the <see cref="JsonNoDataError"/> class.
    /// </summary>
    public JsonNoDataError() : base(
        string.Format(CultureInfo.InvariantCulture,
                      Constants.ErrorMessages.JsonSerializationError)) {

    }
  }
}
