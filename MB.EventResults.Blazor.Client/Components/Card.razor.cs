namespace MB.EventResults.Blazor.Client.Components;

public partial class Card : ComponentBase {
  private string _CssClass = "";

  [Parameter]
  public RenderFragment ChildContent { get; set; }

  [Parameter]
  public bool Shadow { get; set; }

  [Parameter]
  public string Title { get; set; }

  protected override void OnParametersSet() {
    _CssClass = "card card-custom" + (Shadow ? " shadow" : "");
  }
}