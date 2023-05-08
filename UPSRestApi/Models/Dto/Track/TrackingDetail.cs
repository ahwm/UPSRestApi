using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UPSRestApi.Utilities.Internal.Attributes;

namespace UPSRestApi.Models.Dto.Track {
  public class TrackingDetail {
    [JsonProperty("inquiryNumber")]
    public string InquiryNumber { get; set; }

    /// <summary>
    ///   Package details.
    /// </summary>
    [JsonProperty("package")]
    [JsonConverter(typeof(SingleObjectConverter<TrackPackage>))]
    public List<TrackPackage> Package { get; set; }

    [JsonProperty("userRelation")]
    public List<string>? UserRelation { get; set; }

    [JsonProperty("warnings")]
    public List<Common.Warning>? Warnings { get; set; }
  }
}
