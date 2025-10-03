namespace MB.EventResults.Blazor.Client.Components;

public partial class PageTitleContainer : ComponentBase {
  [Parameter]
  public string Title { get; set; }

  [Parameter]
  public string Byline { get; set; }

  [Parameter]
  public RenderFragment ChildContent { get; set; }
}