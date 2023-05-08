namespace UPSRestApi.Exceptions.General {
  public class UnauthorizedError : BaseException {
    public UnauthorizedError(string code = "", string message = "The request requires authentication") : base(code, message, 401) { }
  }
}
