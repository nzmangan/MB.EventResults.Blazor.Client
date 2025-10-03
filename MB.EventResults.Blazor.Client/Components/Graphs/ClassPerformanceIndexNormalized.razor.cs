namespace MB.EventResults.Blazor.Client.Components.Graphs;

public partial class ClassPerformanceIndexNormalized : ComponentBase {
  [Parameter]
  public GradeResult Result { get; set; }

  [Inject]
  public IClassPerformanceIndexNormalizedGraphService GraphService { get; set; }

  [Inject]
  public IGraphRenderingService GraphRenderingService { get; set; }

  protected override async Task OnInitializedAsync() {
    await GraphRenderingService.Render(GraphService, Result);
  }
}