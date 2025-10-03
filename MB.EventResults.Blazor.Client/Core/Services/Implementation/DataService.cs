namespace MB.EventResults.Blazor.Client;

public class DataService(ILogger<DataService> _Logger, HttpClient _Http, IJSRuntime _JsRuntime, IJsonSerializerService _JsonSerializerService, ClientConfiguration _AppConfiguration) : IDataService {
  public async Task<T> Get<T>(string url, Func<T> errorResponse = null) {
    if (url.StartsWith("/api/") && !String.IsNullOrWhiteSpace(_AppConfiguration?.ApiBaseUrl)) {
      url = _AppConfiguration?.ApiBaseUrl + url;
      Console.WriteLine(url);
    }

    using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
    return await Send(requestMessage, errorResponse);
  }

  public async Task<T> Post<T>(string url, Func<T> errorResponse = null) {
    using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
    return await Send(requestMessage, errorResponse);
  }

  private async Task<T> Send<T>(HttpRequestMessage requestMessage, Func<T> errorResponse = null) {
    requestMessage.SetBrowserRequestCache(BrowserRequestCache.NoCache);

    var chv = _AppConfiguration.CompressionHeaderValue;

    if (!String.IsNullOrWhiteSpace(chv)) {
      requestMessage.Headers.TryAddWithoutValidation("x-supports-compression", chv);
    }

    var response = await _Http.SendAsync(requestMessage);

    // auto logout on 401 response
    if (response.StatusCode == HttpStatusCode.Unauthorized) {
      _Logger.LogError($"Call to {requestMessage.RequestUri} returned 401");
      return default;
    }

    if (!response.IsSuccessStatusCode) {
      if (errorResponse == null) {
        var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        throw new Exception(error["message"]);
      } else {
        return errorResponse();
      }
    }

    var isCompressed = response.Content.Headers.ContentType?.MediaType == "binary/octet-stream";

    if (isCompressed) {
      var bytes = await response.Content.ReadAsByteArrayAsync();
      var content = await DecompressBrotli(bytes);
      if (!String.IsNullOrWhiteSpace(content)) {
        return _JsonSerializerService.Deserialize<T>(content);
      }
    }

    try {
      return await response.Content.ReadFromJsonAsync<T>();
    } catch (Exception ex) {
      _Logger.LogError(ex, $"Could not read and deseriliaze json.");
      return default;
    }
  }

  private async Task<string> DecompressBrotli(byte[] compressedBytes) {
    try {
      return await _JsRuntime.InvokeAsync<string>("brotliDecompress", compressedBytes);
    } catch (JSException ex) {
      _Logger.LogError(ex, $"Could not decompress data.");
      return null;
    }
  }
}