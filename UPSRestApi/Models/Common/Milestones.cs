using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class Milestones {
    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("current")]
    public bool Current { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("linkedActivity")]
    public string LinkedActivity { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("subMilestone")]
    public SubMilestone SubMilestone { get; set; }
  }
}
