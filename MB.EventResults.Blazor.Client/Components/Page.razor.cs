namespace MB.EventResults.Blazor.Client.Components;

public partial class Page : ComponentBase {
  [Parameter]
  public RenderFragment ChildContent { get; set; }
}