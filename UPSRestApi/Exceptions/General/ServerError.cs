namespace UPSRestApi.Exceptions.General {
  public class ServerError : BaseException {
    public ServerError(string code = "", string message = "Internal Server Error") : base(code, message, 503) { }
  }
}
