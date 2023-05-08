namespace UPSRestApi.Exceptions.General {
  public class MethodNotAllowedError : BaseException {
    public MethodNotAllowedError(string code = "", string message = "Method not allowed") : base(code, message, 405) { }
  }
}
