using Newtonsoft.Json;
using UPSRestApi.Common;

namespace UPSRestApi.Models.Common {
  public class PackageStatus {
    [JsonProperty("code")]
    public string Code { get; set; }

    /// <summary>
    ///   The status description.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("simplifiedTextDescription")]
    public string? SimplifiedTextDescription { get; set; }

    /// <summary>
    ///   Status code.
    /// </summary>
    [JsonProperty("statusCode")]
    public string StatusCode { get; set; }

    [JsonProperty("type")]
    public Enums.PackageActivityStatusType Type { get; set; }
  }
}
