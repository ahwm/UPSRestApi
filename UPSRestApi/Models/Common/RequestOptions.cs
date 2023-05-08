using Newtonsoft.Json;

namespace UPSRestApi.Models.Common {
  public class RequestOptions {
    /// <summary>
    ///   The time that the request was made from the originating system. UTC time down to milliseconds. Example: 2016-07-14T12:01:33.999
    /// </summary>
    public string? OriginRecordTransactionTimestamp { get; set; }

    /// <summary>
    ///   Enables the user to specify optional processing.
    /// </summary>
    public string? RequestOption { get; set; }
    public string? SubVersion { get; set; }

    /// <summary>
    ///   TransactionReference identifies transactions between client and server.
    /// </summary>
    [JsonProperty("TransactionReference")]
    public TransactionReference TransactionRef { get; set; }

    public RequestOptions() {
      TransactionRef = new TransactionReference();
    }

    public class TransactionReference {
      /// <summary>
      ///   The CustomerContext information which will be echoed during response.
      /// </summary>
      public string CustomerContext { get; set; }
      public string? TransactionIdentifier { get; set; }
    }
  }
}
