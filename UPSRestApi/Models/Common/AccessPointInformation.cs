using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class AccessPointInformation {
    [JsonProperty("pickupByDate")]
    public string PickupByDate { get; set; }
  }
}
