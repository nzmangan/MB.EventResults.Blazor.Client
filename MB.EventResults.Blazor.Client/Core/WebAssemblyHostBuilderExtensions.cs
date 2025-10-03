namespace MB.EventResults.Blazor.Client;

public static class WebAssemblyHostBuilderExtensions {
  public static async Task<T> LoadConfig<T>(this WebAssemblyHostBuilder builder, string fileName) where T : class {
    using var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

    var config = await http.GetAsync(fileName);

    if (config != null && config.IsSuccessStatusCode) {
      string rawConfig = await config.Content.ReadAsStringAsync();
      T c = JsonSerializer.Deserialize<T>(rawConfig, GetConfig());
      return c;
    }

    return null;
  }

  private static JsonSerializerOptions GetConfig() {
    return new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
  }
}