using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class Location {
    /// <summary>
    ///   The Address details where activity occurred.
    /// </summary>
    [JsonProperty("address")]
    public Dto.Track.Address Address { get; set; }

    [JsonProperty("slic")]
    public string Slic { get; set; }
  }
}
