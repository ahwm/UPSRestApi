using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UPSRestApi.Utilities.Internal.Attributes {
  /// <summary>
  ///   Convert the numeric to string when serialize and convert string to the numeric when deserialize
  /// </summary>
  /// <typeparam name="T"></typeparam>
  internal sealed class FormatNumbersAsTextConverter<T> : JsonConverter {
    public override bool CanConvert(Type objectType) {
      return typeof(T).Equals(objectType);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {
      JToken jt = JValue.ReadFrom(reader);
      return jt.Value<T>();
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {
      serializer.Serialize(writer, value?.ToString());
    }
  }
}
