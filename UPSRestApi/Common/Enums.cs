using System.Runtime.Serialization;

namespace UPSRestApi.Common {
  public class Enums {
    public enum AddressClassification {
      [EnumMember(Value = "0")]
      UnClassified,
      [EnumMember(Value = "1")]
      Commercial,
      [EnumMember(Value = "2")]
      Residential
    }

    /// <summary>
    ///   Version of UPS service. 
    /// </summary>
    public enum ApiVersion {
      Blank,
      [EnumMember(Value = "v1")]
      V1,
    }

    /// <summary>
    ///   Valid values for Commodity Regulated Level Code that are used in the Chemical Record container.
    /// </summary>
    public enum CommodityRegulatedLevelCode {
      /// <summary>Excepted Quantity.</summary>
      EQ,
      /// <summary>Fully Regulated.</summary>
      FR,
      /// <summary>Limited Quantity.</summary>
      LQ,
      /// <summary>Lightly Regulated.</summary>
      LR
    }

    /// <summary>
    ///   Valid value list country code.
    /// </summary>
    public enum Country {
      AF,
      AX,
      AL,
      DZ,
      AS,
      AD,
      AO,
      AI,
      AQ,
      AG,
      AR,
      AM,
      AW,
      AU,
      AT,
      AZ,
      BS,
      BH,
      BD,
      BB,
      BY,
      BE,
      BZ,
      BJ,
      BM,
      BT,
      BO,
      BA,
      BW,
      BV,
      BR,
      IO,
      BN,
      BG,
      BF,
      BI,
      BQ,
      KH,
      KP,
      CM,
      CA,
      CV,
      KY,
      CF,
      TD,
      CL,
      CN,
      CX,
      CC,
      CO,
      KM,
      CG,
      CD,
      CK,
      CR,
      CI,
      HR,
      CU,
      CW,
      CY,
      CZ,
      DK,
      DJ,
      DM,
      DO,
      EC,
      EG,
      SV,
      GQ,
      ER,
      EE,
      ET,
      FK,
      FO,
      FJ,
      FI,
      FR,
      GF,
      PF,
      TF,
      GA,
      GM,
      GE,
      DE,
      GH,
      GI,
      GR,
      GL,
      GD,
      GP,
      GU,
      GT,
      GG,
      GN,
      GW,
      GY,
      HT,
      HM,
      VA,
      HN,
      HK,
      HU,
      IS,
      IN,
      IC,
      ID,
      IR,
      IQ,
      IE,
      IM,
      IL,
      IT,
      JM,
      JP,
      JE,
      JO,
      KZ,
      KE,
      KI,
      KR,
      KW,
      KG,
      LA,
      LV,
      LB,
      LS,
      LR,
      LY,
      LI,
      LT,
      LU,
      MO,
      MK,
      MG,
      MW,
      MY,
      MV,
      ML,
      MT,
      MH,
      MQ,
      MR,
      MU,
      YT,
      MX,
      FM,
      MD,
      MC,
      MN,
      ME,
      MS,
      MA,
      MZ,
      MM,
      NA,
      NR,
      NP,
      NL,
      NC,
      NZ,
      NI,
      NE,
      NG,
      NU,
      NF,
      MP,
      NO,
      OM,
      PK,
      PW,
      PS,
      PA,
      PG,
      PY,
      PE,
      PH,
      PN,
      PL,
      PT,
      PR,
      QA,
      RE,
      RO,
      RU,
      RW,
      BL,
      SH,
      KN,
      LC,
      MF,
      PM,
      VC,
      WS,
      SM,
      ST,
      SA,
      SN,
      SS,
      SX,
      RS,
      SC,
      SL,
      SG,
      SK,
      SI,
      SB,
      SO,
      ZA,
      GS,
      ES,
      LK,
      SD,
      SR,
      SJ,
      SZ,
      SE,
      CH,
      SY,
      TW,
      TJ,
      TZ,
      TH,
      TL,
      TG,
      TK,
      TO,
      TT,
      TN,
      TR,
      TM,
      TC,
      TV,
      UG,
      UA,
      AE,
      GB,
      US,
      UM,
      UY,
      UZ,
      VU,
      VE,
      VN,
      VG,
      VI,
      WF,
      EH,
      XK,
      YE,
      ZM,
      ZW,
    }


    public enum DeliveryDateType {
      /// <summary>Rescheduled Delivery Date.</summary>
      RDD,
      /// <summary>Scheduled Delivery Date.</summary>
      SDD,
      /// <summary>Delivery Date.</summary>
      DEL
    }

    public enum DeliveryTimeType {
      /// <summary>Delivery Time.</summary>
      DEL,
      /// <summary>Confirm Delivery Window.</summary>
      CDW,
      /// <summary>Imminent Delivery Window.</summary>
      IDW,
      /// <summary>Estimated Delivery Window.</summary>
      EDW,
      /// <summary>Commit Time.</summary>
      CMT,
      /// <summary>End of Day.</summary>
      EOD
    }

    /// <summary>
    ///   
    /// </summary>
    public enum ElementLevel {
      /// <summary>Commodity.</summary>
      C,
      /// <summary>Header details.</summary>
      H,
      /// <summary>Package.</summary>
      P,
      /// <summary>Shipment.</summary>
      S
    }

    /// <summary>
    ///   Enums API environment mode.
    /// </summary>
    public enum Environment { Production, Test };

    /// <summary>
    ///   The Status type associated to the  tracking activity.
    /// </summary>
    public enum PackageActivityStatusType {
      /// <summary>Delivered.</summary>
      D,
      /// <summary>In Transit.</summary>
      I,
      /// <summary>Billing Information Received.</summary>
      M,
      /// <summary>Billing Information Voided.</summary>
      MV,
      /// <summary>Pickup.</summary>
      P,
      /// <summary>Exception.</summary>
      X,
      /// <summary>Returned to Shipper.</summary>
      RS,
      /// <summary>Delivered Origin CFS (Freight Only).</summary>
      DO,
      /// <summary>Delivered Destination CFS (Freight Only).</summary>
      DD,
      /// <summary>Warehousing (Freight Only).</summary>
      W,
      /// <summary>Not Available.</summary>
      NA,
      /// <summary> Out for Delivery.</summary>
      O
    }

    /// <summary>
    ///   The packing group category associated to the specified commodity
    /// </summary>
    public enum PackagingGroupType {
      [EnumMember(Value = null)]
      Blank,
      [EnumMember(Value = "I")]
      I,
      [EnumMember(Value = "II")]
      II,
      [EnumMember(Value = "III")]
      III
    }

    public enum PickupType {
      [EnumMember(Value = "20")]
      AirServiceCenter,
      [EnumMember(Value = "03")]
      CustomerCounter,
      [EnumMember(Value = "01")]
      DailyPickup,
      [EnumMember(Value = "19")]
      LetterCenter,
      [EnumMember(Value = "06")]
      OneTimePickup
    }

    /// <summary>
    ///   Valid values for the Acceptance Autdit Pre-check that are defined in the Shipment package request.
    ///   When a HazMat shipment specifies AllPackedInOneIndicator and the regulation set for that shipment is IATA, 
    ///   Q-Value specifies exactly one of the following values
    /// </summary>
    public enum QValue {
      [EnumMember(Value = "0.1")]
      ZeroPointOne,
      [EnumMember(Value = "0.2")]
      ZeroPointTwo,
      [EnumMember(Value = "0.3")]
      ZeroPointThree,
      [EnumMember(Value = "0.4")]
      ZeroPointFour,
      [EnumMember(Value = "0.5")]
      ZeroPointFive,
      [EnumMember(Value = "0.6")]
      ZeroPointSix,
      [EnumMember(Value = "0.7")]
      ZeroPointSeven,
      [EnumMember(Value = "0.8")]
      ZeroPointEight,
      [EnumMember(Value = "0.9")]
      ZeroPointNine,
      [EnumMember(Value = "1.0")]
      OnePointZero
    }

    /// <summary>
    ///   Valid values for the Acceptance Autdit Pre-check or Pre-Notifcation which are defined in the Shipment container.
    /// </summary>
    public enum RegulationSet {
      /// <summary>European Agreement Concerning the International Carriage of Dangerous Goods by Road.</summary>
      [EnumMember(Value = "ADR")]
      ADR,
      /// <summary>HazMat regulated by US Dept. of Transportation within the U.S. or ground shipments to Canada.</summary>
      [EnumMember(Value = "49CFR")]
      FourtyNineCFR,
      /// <summary>United States Code of Federal Regulations, Title 49 (Transportation by air or ground)).</summary>
      [EnumMember(Value = "IATA")]
      IATA,
      /// <summary>Canadian Transport Dangerous Goods regulations.</summary>
      TDG
    };

    /// <summary>
    ///   Valid values transport category
    /// </summary>
    public enum TransportCategory {
      [EnumMember(Value = "0")]
      Zero,
      [EnumMember(Value = "1")]
      One,
      [EnumMember(Value = "2")]
      Two,
      [EnumMember(Value = "3")]
      Three,
      [EnumMember(Value = "4")]
      Fourth,
    }

    /// <summary>
    ///   The method  of stransport.
    /// </summary>
    public enum TransportationMode {
      /// <summary>Ground.</summary>
      GND,
      /// <summary>Cargo Aircraft Only.</summary>
      CAO,
      /// <summary>Passenger Aircraft.</summary>
      PAX
    };

    public enum WeightUnitOfMeasurement {
      /// <summary>Pounds.</summary>
      LBS,
      /// <summary>Kilograms.</summary>
      KGS
    }

    public enum WeightUnitOfMeasurement2 {
      [EnumMember(Value = "cyl")]
      Cylinder,
      [EnumMember(Value = "gal")]
      Gallon,
      [EnumMember(Value = "g")]
      Gram,
      [EnumMember(Value = "kgs")]
      Kilograms,
      [EnumMember(Value = "l")]
      liliter,
      [EnumMember(Value = "mg")]
      Milligram,
      [EnumMember(Value = "ml")]
      Milliliter,
      [EnumMember(Value = "pt")]
      Pint,
      /// <summary>Pounds.</summary>
      [EnumMember(Value = "lbs")]
      Pound,
      [EnumMember(Value = "qt")]
      Quart,
    }
  }
}
