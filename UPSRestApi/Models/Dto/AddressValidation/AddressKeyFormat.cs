using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Models.Dto.AddressValidation {
  public class AddressKeyFormat {
    /// <summary>
    ///   Name of business, company or person.
    /// </summary>
    [JsonProperty("ConsigneeName")]
    public string? CompanyName { get; set; }

    /// <summary>
    ///   Name of the building.
    /// </summary>
    public string? AttentionName { get; set; }

    public string? AddressLine { get; set; }

    /// <summary>
    ///  City or Town Name.
    /// </summary>
    [JsonProperty("PoliticalDivision2")]
    public string? City { get; set; }

    /// <summary>
    ///   Country/Territory Code.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.Country CountryCode { get; set; }

    /// <summary>
    ///   Postal Code.
    /// </summary>
    [JsonProperty("PostcodePrimaryLow")]
    public string? PostalCode { get; set; }

    /// <summary>
    ///   4 digit Postal Code extension. For US use only.
    /// </summary>
    public string? PostcodeExtendedLow { get; set; }

    /// <summary>
    ///   Puerto Rico Political Division 3. Only valid for Puerto Rico. If this node is present the following tags will be ignored:
    ///   - Political Division 2
    ///   - Political Division 1
    ///   - PostcodePrimaryLow
    ///   - PostcodeExtendedLow
    /// </summary>
    public string? Region { get; set; }

    /// <summary>
    ///   State or Province/Territory Name.
    /// </summary>
    [JsonProperty("PoliticalDivision1")]
    public string? StateProvinceCode { get; set; }

    /// <summary>
    ///   Valid only for US or PR origins only,
    /// </summary>
    public string? Urbanization { get; set; }

    public AddressKeyFormat() : this(null) { }
    public AddressKeyFormat(Models.Common.IAddress address, bool regionRequestIndicator = false) {
      if (address != null) {
        this.AddressLine = address.AddressLine;
        this.AttentionName = address.AttentionName;
        this.CompanyName = address.CompanyName;
        this.CountryCode = address.CountryCode;
        this.Region = address.Region;

        // Ignore the follow property if regionRequestIndicator is true
        if (!regionRequestIndicator) {

          this.City = address.City;
          this.StateProvinceCode = address.StateProvinceCode;
          this.PostalCode = address.PostalCode;
          this.PostcodeExtendedLow = address.PostcodeExtendedLow;
        }
      }
    }
  }
}
