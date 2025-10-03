﻿namespace MB.EventResults.Blazor.Client.Components.Graphs;

public partial class MistakeTotal : ComponentBase {
  [Parameter]
  public GradeResult Result { get; set; }

  [Inject]
  public IMistakeTotalGraphService GraphService { get; set; }

  [Inject]
  public IGraphRenderingService GraphRenderingService { get; set; }

  protected override async Task OnInitializedAsync() {
    await GraphRenderingService.Render(GraphService, Result);
  }
}