using UPSRestApi.Models.Common;

namespace UPSRestApi.Models.Dto.DangerousGoods.AcceptanceAuditPreCheck {
  public interface IAcceptanceAuditPreCheckRequest {
    /// <summary>
    ///   The time that the request was made from the originating system. UTC time down to milliseconds.
    ///   <example>2016-07-14T12:01:33.999</example>
    /// </summary>
    string? OriginRecordTransactionTimestamp { get; set; }

    /// <summary>
    ///   Contains shipment information.
    /// </summary>
    RequestOptions Request { get; set; }

    /// <summary>
    ///   Contains Dangerous Goods Utility Acceptance Audit Pre-check request criteria elements.
    /// </summary>
    Shipment Shipment { get; set; }
  }

  public class AcceptanceAuditPreCheckRequest : IAcceptanceAuditPreCheckRequest {
    /// <inheritdoc/>
    public string? OriginRecordTransactionTimestamp { get; set; }

    /// <inheritdoc/>
    public RequestOptions Request { get; set; }

    /// <inheritdoc/>
    public Shipment Shipment { get; set; }

    public AcceptanceAuditPreCheckRequest() {
      this.Request = new RequestOptions();
      Shipment = new Shipment();
    }

  }
}
