using UPSRestApi.Models.Common;

namespace UPSRestApi.Models.Dto.DangerousGoods.PreNotification {
  public interface IPreNotificationRequest {
    RequestOptions Request { get; set; }

    /// <summary>
    ///   Shipment information.
    /// </summary>
    Shipment Shipment { get; set; }
  }

  public class PreNotificationRequest : IPreNotificationRequest {
    public RequestOptions Request { get; set; }

    /// <inheritdoc/>>
    public Shipment Shipment { get; set; }

    public PreNotificationRequest() {
      this.Request = new RequestOptions();
      this.Shipment = new Shipment();
    }


  }
}
