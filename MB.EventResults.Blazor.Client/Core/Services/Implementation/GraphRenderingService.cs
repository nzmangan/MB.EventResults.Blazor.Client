﻿using Microsoft.JSInterop;

namespace MB.EventResults.Blazor.Client;

public class GraphRenderingService(IJSRuntime _JSRuntime) : IGraphRenderingService {
  public async Task Render<T>(IGraphTypeService<T> graphService, GradeResult result) {
    await Task.Delay(10);
    await _JSRuntime.InvokeVoidAsync("owGraph.show", graphService.ChartType, graphService.GetLabels(result), graphService.GetDataSeries(result), graphService.OptionType, 0, 100);
  }

  public async Task Clear() {
    await _JSRuntime.InvokeVoidAsync("owGraph.clear");
    await Task.Delay(10);
  }
}