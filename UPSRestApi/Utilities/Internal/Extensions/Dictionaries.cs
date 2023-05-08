namespace UPSRestApi.Utilities.Internal.Extensions {
  /// <summary>
  ///   Dictionary extensions.
  /// </summary>
  public static class Dictionaries {
    /// <summary>
    ///   Add a key-value to a dictionary if the key does not exists, otherwise update the value
    /// </summary>
    /// <param name="dictionary">The dictionary to add/update the key-value pair in.</param>
    /// <param name="key">The key to add/update.</param>
    /// <param name="value">The value to add/update.</param>
    public static void AddOrUpdate(this IDictionary<string, object> dictionary, string key, object value) {
      try {
        dictionary.Add(key, value);
      } catch {
        dictionary[key] = value;
      }
    }
  }
}
