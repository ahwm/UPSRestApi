using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UPSRestApi.Utilities.Internal.Attributes;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Models.Common {
  /// <summary>
  ///   Chemical record information.
  /// </summary>
  public class ChemicalRecord {

    /// <summary>
    ///   Additional remarks or special provision information.
    ///   Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation.
    ///   Additional information that may be required by regulation about a hazardous material, such as, 
    ///   “Limited Quantity”, DOT-SP numbers, EX numbers.
    /// </summary>
    public string? AdditionalDescription { get; set; }

    /// <summary>
    ///   Indicates the hazmat shipment/package is all packed in one.
    /// </summary>
    public string? AllPackedInOneIndicator { get; set; }

    /// <summary>
    ///   This is the hazard class associated to the specified commodity.
    ///   Required if CommodityRegulatedLevelCode is ‘LQ’ or ‘FR’.
    ///   Details at <see href="https://www.ups.com/us/en/support/shipping-support/shipping-special-care-regulated-items/hazardous-materials-guide/hazardous-material-service-definition/dangerous-goods-chemical-tables.page"/> UPS Chemical Table.
    /// </summary>
    public string? ClassDivisionNumber { get; set; }

    /// <summary>
    ///   Identifies the Chemical Record.
    /// </summary>
    public string? ChemicalRecordIdentifier { get; set; }

    /// <summary>
    ///   Indicates the type of commodity.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.CommodityRegulatedLevelCode CommodityRegulatedLevelCode { get; set; }

    /// <summary>
    ///   The emergency information, contact name and/or contract number, required to be communicated 
    ///   when a call is placed to the EmergencyPhoneNumber.
    /// </summary>
    public string? EmergencyContact { get; set; }

    /// <summary>
    ///   24 Hour Emergency Phone Number of the shipper. Valid values for this field are (0) through (9) with trailing blanks. 
    ///   For numbers within the U.S., the layout is '1', area code, 7-digit number. 
    ///   For all other countries or territories the layout is country or territory code, area code, number.
    ///   The following are restricted in the phone number period “.”, dash “-“, plus sign “+” and 
    ///   conventional parentheses “(“ and “)”, “EXT" or "OPT”(each shown within quotation marks here for clarity
    /// </summary>
    public string? EmergencyPhone { get; set; }

    /// <summary>
    ///   The package type code identifying the type of packaging used for the commodity. (Ex: Fiberboard Box). 
    ///   Required if CommodityRegulatedLevelCode = LQ or FR.
    /// </summary>
    public string? HazardLabelRequired { get; set; }

    /// <summary>
    ///   This is the ID number (UN/NA/ID) for the specified commodity.
    ///   Required if CommodityRegulatedLevelCode = LR, LQ or FR and if the field
    ///   applies to the material by regulation.
    ///   UN/NA/ID Identification Number assigned to the specified regulated good. (Include the UN/NA/ID as part of the entry).
    /// </summary>
    public string? IDNumber { get; set; }

    /// <summary>
    ///   Presence/Absence Indicator. Any value is ignored. Presence indicates that shipment is over pack.
    /// </summary>
    public string? OverPackedIndicator { get; set; }

    /// <summary>
    ///   The packing group category associated to the specified commodity
    ///   Valid values are: I, II, III, blank.
    ///   UN/NA/ID Identification Number assigned to the specified regulated 
    ///   good. (Include the UN/NA/ID as part of the entry).
    ///   Details at <see href="https://www.ups.com/us/en/support/shipping-support/shipping-special-care-regulated-items/hazardous-materials-guide/hazardous-material-service-definition/dangerous-goods-chemical-tables.page"/> UPS Chemical Table
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.PackagingGroupType? PackagingGroupType { get; set; }

    /// <summary>
    ///   The packing instruction related to the chemical record.
    ///   Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation.
    /// </summary>
    public string? PackagingInstructionCode { get; set; }

    /// <summary>
    ///   The package type code identifying the type of packaging used for the commodity. (Ex: Fiberboard Box). 
    ///   Required if CommodityRegulatedLevelCode = LQ or FR.
    /// </summary>
    public string? PackagingType { get; set; }

    /// <summary>
    ///   The number of pieces of the specific commodity.
    ///   Required if CommodityRegulatedLevelCode = LQ or FR.
    /// </summary>
    [JsonConverter(typeof(FormatNumbersAsTextConverter<int?>))]
    public int? PackagingTypeQuantity { get; set; }

    /// <summary>
    ///   The Proper Shipping Name assigned by ADR, CFR or IATA.
    ///   Required if CommodityRegulatedLevelCode = LR, LQ or FR.
    ///   Details at <see href="https://www.ups.com/us/en/support/shipping-support/shipping-special-care-regulated-items/hazardous-materials-guide/hazardous-material-service-definition/dangerous-goods-chemical-tables.page"/> UPS Chemical Table column BASIC DESCRIPTION FOR GROUND AND AIR
    /// </summary>
    public string? ProperShippingName { get; set; }

    /// <summary>
    ///   Required if CommodityRegulatedLevelCode = LQ or FR.The numerical value of 
    ///   the mass capacity of the regulated good.
    /// </summary>
    [JsonConverter(typeof(FormatNumbersAsTextConverter<double>))]
    public double Quantity { get; set; }

    /// <summary>
    ///   When a HazMat shipment specifies AllPackedInOneIndicator and
    ///   the regulation set for that shipment is IATA, 
    ///   Q-Value specifiesexactly one of the following values: 0.1; 0.2; 0.3; 0.4; 0.5; 0.6; 0.7;0.8; 0.9; 1.0
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public CommonEnums.QValue? QValue { get; set; }

    /// <summary>
    ///   Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to
    ///   the material by regulation.If reportable quantity is met, RQ should be entered.
    /// </summary>
    public string? ReportableQuantity { get; set; }

    /// <summary>
    ///   Required if CommodityRegulatedLevelCode is ‘LQ’ or ‘FR’.
    ///   Secondary hazardous characteristics of a package. (There can be more than one – separate each with a comma).
    /// </summary>
    public string? SubRiskClass { get; set; }

    /// <summary>
    ///   The technical name (when required) for the specifiedcommodity.
    ///   Required if CommodityRegulatedLevelCode = LQ or FR and if the field applies to the material by regulation.
    /// </summary>
    public string? TechnicalName { get; set; }

    /// <summary>
    ///   Valid values: 0 to 4.
    /// </summary>
    public string? TransportCategory { get; set; }

    /// <summary>
    ///   Defines what is restricted to pass through a tunnel.
    /// </summary>
    public string? TunnelRestrictionCode { get; set; }

    /// <summary>
    ///   The unit of measure used for the mass capacity of the regluated good.
    ///   Valid values are: ml, L, g, mg, kg, cylinder, pound, pint, quart, gallong, ounce etc.
    /// </summary>
    public CommonEnums.WeightUnitOfMeasurement2? UOM { get; set; }
  }
}
