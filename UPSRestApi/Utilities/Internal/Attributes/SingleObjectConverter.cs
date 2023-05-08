using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace UPSRestApi.Utilities.Internal.Attributes {
  /// <summary>
  ///   The SingleObjectConverter converts a JSON property to IEnumerable<typeparamref name="T"/> when NewtonJson Deserialize.
  /// </summary>
  /// <typeparam name="T">class|object|integer|float|string</typeparam>
  internal class SingleObjectConverter<T> : JsonConverter {
    public override bool CanConvert(Type objectType) {
      return typeof(T).Equals(objectType);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {
      var test = reader.Path;

      if (reader.TokenType == JsonToken.StartObject) {

        return ConvertSystemTypeToList<T>(reader, serializer);
      }

      if (reader.TokenType == JsonToken.String) {

        return ConvertSystemTypeToList<string>(reader, serializer);
      }

      if (reader.TokenType == JsonToken.Integer) {

        return ConvertSystemTypeToList<int>(reader, serializer);
      }

      if (reader.TokenType == JsonToken.Float) {

        return ConvertSystemTypeToList<float>(reader, serializer);
      }

      return serializer.Deserialize<List<T>>(reader);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {
      throw new NotImplementedException();
    }

    private List<T>? ConvertSystemTypeToList<T>(JsonReader reader, JsonSerializer serializer) {
      T val = (T)serializer.Deserialize(reader, typeof(T));

      if (val != null) {

        return new List<T>() { (T)val };
      }

      return null;
    }
  }
}
