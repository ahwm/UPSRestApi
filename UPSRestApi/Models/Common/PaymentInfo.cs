using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Common {
  public class PaymentInfo {
    [JsonProperty("amount"), JsonConverter(typeof(FormatNumbersAsTextConverter<double>))]
    public double Amount { get; set; }
    [JsonProperty("currency")]
    public string Currency { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("paid")]
    public bool Paid { get; set; }

    [JsonProperty("paymentMethod")]
    public string PaymentMethod { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
  }
}
