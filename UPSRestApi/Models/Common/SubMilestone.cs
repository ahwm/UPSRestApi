using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class SubMilestone {
    [JsonProperty("category")]
    public string Category { get; set; }
  }
}
