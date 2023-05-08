namespace UPSRestApi.Exceptions.General {
  public class UnknowError : BaseException {
    public UnknowError(string code = "", string message = "Unknow Error") : base(code, message, 500) { }
  }
}
