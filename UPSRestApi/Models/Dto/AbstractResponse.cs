using UPSRestApi.Models.Dto.Common;

namespace UPSRestApi.Models.Dto {
  public interface IAbstractResponse {
    Response Response { get; set; }
  }

  public abstract class AbstractResponse : IAbstractResponse {
    public Response Response { get; set; }
  }
}
