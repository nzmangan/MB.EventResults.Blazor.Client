namespace MB.EventResults.Blazor.Client.Components.Graphs;

public partial class Data : ComponentBase {
  [Parameter]
  public GradeResult Result { get; set; }

  [Inject]
  public IJSRuntime JSRuntime { get; set; }

  [Inject]
  public IJsonSerializerService JsonSerializerService { get; set; }

  protected async Task DownloadFile() {
    await JSRuntime.InvokeVoidAsync("window.downloadString", $"{Result.Name}.json", JsonSerializerService.Serialize(Result));
  }
}