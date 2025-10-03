
namespace MB.EventResults.Blazor.Client;

public class ClassMistakeTotalGraphService : IClassMistakeTotalGraphService {
  public const string Label = "Class Mistakes (Total)";

  public string ChartType => "line";

  public string OptionType => "Mistakes2";

  public List<DataSerie<int>> GetDataSeries(GradeResult response) {
    return [new DataSerie<int> {
      Label = "Mistakes",
      Data = GetValues(response),
      Color = ChartDefaults.Colors[0],
    }];
  }

  private List<int> GetValues(GradeResult response) {
    if (response.Runners is null || response.Runners.Count < 1) {
      return [];
    }

    List<int> percentage = [];

    for (var i = 0; i < response.Runners[0].Splits?.Count; i++) {
      int timeCount = 0;
      int mistakeCount = 0;

      foreach (var r in response.Runners) {
        if (r.Splits[i].Leg.HasValue) {
          timeCount++;
          if (r.Splits[i].TimeLoss.HasValue) {
            mistakeCount++;
          }
        }
      }

      percentage.Add(mistakeCount * 100 / timeCount);
    }

    return percentage;
  }

  public List<string> GetLabels(GradeResult response) {
    return ChartDefaults.GetChartLabels([.. response.Legs.Select(p => p.Id)], false);
  }
}