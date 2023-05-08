using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class DeliveryInformation {
    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("receivedBy")]
    public string ReceivedBy { get; set; }

    [JsonProperty("signature")]
    public Signature Signature { get; set; }
  }
}
