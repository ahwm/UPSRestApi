using System.Runtime.Serialization;

namespace UPSRestApi.Exceptions {
  public interface IBaseException : ISerializable {
    string? Code { get; set; }
    int? StatusCode { get; set; }
  }

  public class BaseException : Exception, IBaseException {
    public string? Code { get; set; }
    public int? StatusCode { get; set; }

    public BaseException(string code, string message, int? statusCode = null) : base(message) {
      this.Code = code;
      this.StatusCode = statusCode;
    }

    public override string ToString() {
      string errorString = $@"{Code} ({StatusCode}): {Message}";
      return errorString;
    }

  }
}
