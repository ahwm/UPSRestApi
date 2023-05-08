using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class Signature {
    [JsonProperty("image")]
    public string Image { get; set; }
  }
}
