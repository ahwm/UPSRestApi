using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UPSRestApi.Models.Common;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.Track {
  public class TrackPackage {
    [JsonProperty("accessPointInformation")]
    public AccessPointInformation AccessPointInformation { get; set; }

    /// <summary>
    ///   The activities associated with the inquiryNumber.
    /// </summary>
    [JsonProperty("activity")]
    [JsonConverter(typeof(SingleObjectConverter<PackageActivity>))]
    public List<PackageActivity> Activity { get; set; }

    [JsonProperty("additionalAttributes")]
    [JsonConverter(typeof(SingleObjectConverter<string>))]
    public List<string>? AdditionalAttributes { get; set; }

    [JsonProperty("additionalServices")]
    [JsonConverter(typeof(SingleObjectConverter<string>))]
    public List<string>? AdditionalServices { get; set; }

    [JsonProperty("alternateTrackingNumber")]
    [JsonConverter(typeof(SingleObjectConverter<AlternateTrackingNumber>))]
    public List<AlternateTrackingNumber>? AlternateTrackingNumber { get; set; }

    [JsonProperty("currentStatus")]
    public PackageStatus? CurrentStatus { get; set; }

    /// <summary>
    ///   Delivery date details associated with the package.
    /// </summary>
    [JsonProperty("deliveryDate")]
    [JsonConverter(typeof(SingleObjectConverter<DeliveryDate>))]
    public List<DeliveryDate> DeliveryDate { get; set; }

    [JsonProperty("deliveryInformation")]
    public DeliveryInformation? DeliveryInformation { get; set; }

    [JsonProperty("deliveryTime")]
    public DeliveryTime DeliveryTime { get; set; }


    [JsonProperty("milestones")]
    [JsonConverter(typeof(SingleObjectConverter<Milestones>))]
    public List<Milestones>? Milestones { get; set; }

    [JsonProperty("packageAddress")]
    [JsonConverter(typeof(SingleObjectConverter<PackageAddress>))]
    public List<PackageAddress>? PackageAddress { get; set; }

    [JsonProperty("packageCount")]
    public int PackageCount { get; set; }

    [JsonProperty("paymentInformation")]
    [JsonConverter(typeof(SingleObjectConverter<PaymentInfo>))]
    public List<PaymentInfo>? PaymentInformation { get; set; }

    [JsonProperty("referenceNumber")]
    [JsonConverter(typeof(SingleObjectConverter<ReferenceNumber>))]
    public ReferenceNumber? ReferenceNumber { get; set; }
    [JsonProperty("service")]
    public Service? Service { get; set; }

    [JsonProperty("statusCode")]
    public string? StatusCode { get; set; }

    [JsonProperty("statusDescription")]
    public string? StatusDescription { get; set; }

    [JsonProperty("suppressionIndicators")]
    [JsonConverter(typeof(SingleObjectConverter<string>))]
    public List<string>? SuppressionIndicators { get; set; }

    [JsonProperty("trackingNumber")]
    public string TrackingNumber { get; set; }

    [JsonProperty("weight")]
    public PackageWeight? Weight { get; set; }
  }
}
