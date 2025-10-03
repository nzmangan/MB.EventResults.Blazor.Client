namespace MB.EventResults.Blazor.Client;

public class ClientConfiguration {
  public string CompressionHeaderValue { get; set; }
  public string ApiBaseUrl { get; set; }
  public string BaseUrl { get; set; }
  public string ApiClassUrl { get; set; }
  public string ApiGradesUrl { get; internal set; }
}