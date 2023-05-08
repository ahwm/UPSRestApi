namespace UPSRestApi.Exceptions.General {
  public class NotFoundError : BaseException {
    public NotFoundError(string code = "", string message = "URL does not exist or resource not found") : base(code, message, 404) { }
  }
}
