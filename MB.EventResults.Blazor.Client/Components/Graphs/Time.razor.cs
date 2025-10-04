namespace MB.EventResults.Blazor.Client.Components.Graphs;

public partial class Time : ComponentBase {
  [Parameter]
  public GradeResult Result { get; set; }

  [Inject]
  public ITextService TextService { get; set; }

  [Inject]
  public ITimeGraphService GraphService { get; set; }

  [Inject]
  public IGraphRenderingService GraphRenderingService { get; set; }

  [Inject]
  public IGraphOptionsService GraphOptionsService { get; set; }

  protected override async Task OnInitializedAsync() {
    await RenderGraph();
  }

  private async Task RenderGraph() {
    await GraphRenderingService.Render(GraphService, Result);
  }

  private async Task UpdateReference(ChangeEventArgs e) {
    var selectedValue = e.Value.ToString();
    if (selectedValue != "superman") {
      GraphOptionsService.Reference = Result?.Runners?.FirstOrDefault(p => p.GetName() == selectedValue);
    } else {
      GraphOptionsService.Reference = new Runner { FirstName = "superman" };
    }
    await RenderGraph();
  }
}