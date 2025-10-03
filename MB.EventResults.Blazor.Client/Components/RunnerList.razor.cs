namespace MB.EventResults.Blazor.Client.Components;

public partial class RunnerList : ComponentBase {
  [Parameter]
  public List<Runner> Runners { get; set; }
}