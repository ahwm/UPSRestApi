namespace UPSRestApi.Exceptions.General {
  public class InvalidRequestError : BaseException {
    public InvalidRequestError(string code, string message, int? statuscode) : base(code, message, statuscode) { }
  }
}
