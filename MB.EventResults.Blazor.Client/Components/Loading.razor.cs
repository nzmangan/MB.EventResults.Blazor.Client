namespace MB.EventResults.Blazor.Client.Components;

public partial class Loading : ComponentBase {
  [Parameter]
  public bool Show { get; set; }

  [Parameter]
  public bool Table { get; set; }

  [Parameter]
  public string ColSpan { get; set; }

  [Parameter]
  public RenderFragment ChildContent { get; set; }
}