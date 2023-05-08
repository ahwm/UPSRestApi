using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class AlternateTrackingNumber {
    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
  }
}
