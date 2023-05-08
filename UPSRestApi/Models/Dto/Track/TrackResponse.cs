using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.Track {
  public class TrackResponse {
    /// <summary>
    ///    The Shipment details associated to the inquiry numbers.
    /// </summary>
    [JsonProperty("shipment")]
    [JsonConverter(typeof(SingleObjectConverter<TrackingDetail>))]
    public List<TrackingDetail> Shipment { get; set; }

    public TrackResponse() {
      this.Shipment = new List<TrackingDetail>();
    }
  }
}
