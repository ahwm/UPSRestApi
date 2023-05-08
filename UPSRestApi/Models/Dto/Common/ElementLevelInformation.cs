using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UPSRestApi.Common;
namespace UPSRestApi.Models.Dto.Common {
  /// <summary>
  ///   Provides more information about  the element that represents the  alert. 
  /// </summary>
  public class ElementLevelInformation {
    /// <summary>
    ///   Define type of element in  request.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public Enums.ElementLevel? Level { get; set; }

    /// <summary>
    ///   More information about  the type of element.  Returned if Level is P or C.
    /// </summary>
    public ElementIdentifier ElementIdentifier { get; set; }
  }
}
