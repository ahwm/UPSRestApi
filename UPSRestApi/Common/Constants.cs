namespace UPSRestApi.Common {
  public static class Constants {
    /// <summary>
    ///   Default error message for JsonDeserialization <see cref="UPSRestApi.Utilities.Internal.JsonSerialization"/>.
    /// </summary>
    public static class ErrorMessages {
      public const string JsonDeserializationError = "Error deserializing JSON into object of type {0}.";
      public const string JsonSerializationError = "Error serializing {0} object into JSON.";
    }
  }
}
