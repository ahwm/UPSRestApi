using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Models.Common {
  public interface IAddress {
    /// <summary>
    ///   Street Address 
    /// </summary>
    string? AddressLine { get; set; }

    /// <summary>
    ///   Block Address 
    /// </summary>
    string? AddressLine2 { get; set; }

    /// <summary>
    ///   Block Address 
    /// </summary>
    string? AddressLine3 { get; set; }

    /// <summary>
    ///   Name of the person
    /// </summary>
    string? AttentionName { get; set; }

    /// <summary>
    ///   City or Town name
    /// </summary>
    string? City { get; set; }

    /// <summary>
    ///   Name of the business, company
    /// </summary>
    string? CompanyName { get; set; }

    /// <summary>
    ///   Country or territory code
    /// </summary>
    CommonEnums.Country CountryCode { get; set; }

    /// <summary>
    ///   Postal code
    /// </summary>
    string? PostalCode { get; set; }

    /// <summary>
    ///   ///   4 digit Postal code extension. For US use only
    /// </summary>
    string? PostcodeExtendedLow { get; set; }

    /// <summary>
    ///   Valid only for US or PR origins only
    /// </summary>
    string? Region { get; set; }

    /// <summary>
    /// Location state or province code
    /// </summary>
    string? StateProvinceCode { get; set; }

    /// <summary>
    ///   Only valid for Puerto Rico
    /// </summary>
    string? Urbanization { get; set; }
  }

  public class Address : IAddress {
    public string? AttentionName { get; set; }

    /// <inheritdoc/>
    public string? AddressLine { get; set; }

    /// <inheritdoc/>
    public string? AddressLine2 { get; set; }

    /// <inheritdoc/>
    public string? AddressLine3 { get; set; }

    /// <inheritdoc/>
    public string? City { get; set; }

    /// <inheritdoc/>
    public string? CompanyName { get; set; }

    /// <inheritdoc/>
    public string? StateProvinceCode { get; set; }

    /// <inheritdoc/>
    public string? PostalCode { get; set; }

    /// <inheritdoc/>
    public string? PostcodeExtendedLow { get; set; }

    /// <inheritdoc/>
    public string? Urbanization { get; set; }

    /// <inheritdoc/>
    public string? Region { get; set; }

    /// <inheritdoc/>
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.Country CountryCode { get; set; }

    public Address() {
      CountryCode = CommonEnums.Country.US;
    }
  }
}
