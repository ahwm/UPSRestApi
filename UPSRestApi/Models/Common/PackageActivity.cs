using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  /// <summary>
  ///   The activity associated with the inquiryNumber.
  /// </summary>
  public class PackageActivity {
    [JsonProperty("date")]
    public string Date { get; set; }

    /// <summary>
    ///   The location where activity occurred.
    /// </summary>
    [JsonProperty("location")]
    public Location Location { get; set; }

    /// <summary>
    ///   The Status associated to the  activity.
    /// </summary>
    [JsonProperty("status")]
    public PackageStatus Status { get; set; }

    /// <summary>
    ///   The time of the activity Format: HHMMSS (24 hr) Local time.
    /// </summary>
    [JsonProperty("time")]
    public string Time { get; set; }
  }
}
