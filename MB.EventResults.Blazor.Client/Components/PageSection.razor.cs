namespace MB.EventResults.Blazor.Client.Components;

public partial class PageSection : ComponentBase {
  [Parameter]
  public RenderFragment ChildContent { get; set; }
}