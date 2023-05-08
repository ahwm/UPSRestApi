using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class Error {
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
  }
}
