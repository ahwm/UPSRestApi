using Newtonsoft.Json;

namespace UPSRestApi.Models.Dto.Common {
  public class Alert {
    public string Code { get; set; }
    public string? Description { get; set; }
  }

  public class Response {
    public ResponseStatus ResponseStatus { get; set; }
    public Alert? Alert { get; set; }
    public AlertDetail? AlertDetail { get; set; }
    public TransactionReference? TransactionReference { get; set; }

  }

  public class ResponseStatus {
    public string Code { get; set; }
    public string Description { get; set; }
  }

  public class TransactionReference {
    public string CustomerContext { get; set; }
  }

  public class Warning {
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
  }
}
