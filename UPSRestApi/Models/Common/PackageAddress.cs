using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class PackageAddress {
    [JsonProperty("address")]
    public Address Address { get; set; }
    [JsonProperty("attentionName")]
    public string AttentionName { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
  }
}
