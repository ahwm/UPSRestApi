namespace UPSRestApi.Exceptions.General {
  public class InternalServerError : BaseException {
    public InternalServerError(string code = "", string message = "The service/resource is not available") : base(code, message, 500) { }
  }
}
