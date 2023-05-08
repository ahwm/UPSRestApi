using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UPSRestApi.Common;
using UPSRestApi.Models.Common;

namespace UPSRestApi.Models.Dto.Track {
  public class Address : IAddress {
    [JsonProperty("addressLine1")]
    public string? AddressLine { get; set; }

    [JsonProperty("addressLine2")]
    public string? AddressLine2 { get; set; }

    [JsonProperty("addressLine3")]
    public string? AddressLine3 { get; set; }

    [JsonProperty("AttentionName")]
    public string? AttentionName { get; set; }

    [JsonProperty("city")]
    public string? City { get; set; }

    [JsonProperty("CompanyName")]
    public string? CompanyName { get; set; }

    [JsonProperty("country")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Enums.Country CountryCode { get; set; }

    [JsonProperty("postalCode")]
    public string? PostalCode { get; set; }

    [JsonProperty("PostcodeExtendedLow")]
    public string? PostcodeExtendedLow { get; set; }

    [JsonProperty("Region")]
    public string? Region { get; set; }

    [JsonProperty("stateProvince")]
    public string? StateProvinceCode { get; set; }

    [JsonProperty("Urbanization")]
    public string? Urbanization { get; set; }

  }
}
