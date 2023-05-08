namespace UPSRestApi.Models.Common {
  public class Service {
    /// <summary>
    ///   UPS service type code.
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    ///   Description of the service code. 
    ///   <example>Examples are Next Day Air,Worldwide Express, and Ground.</example>
    /// </summary>
    public string? Description { get; set; }

    public Service(string code = "", string description = null) {
      this.Code = code;
      this.Description = description;
    }
  }
}
