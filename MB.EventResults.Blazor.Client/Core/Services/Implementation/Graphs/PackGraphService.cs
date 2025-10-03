namespace MB.EventResults.Blazor.Client;

public class PackGraphService : IPackGraphService {
  public const string Label = "Pack";

  public string ChartType => "line";

  public string OptionType => "Pack";

  public List<DataSerie<double?>> GetDataSeries(GradeResult response) {
    return DatasetHelper.BuildSeries(response, GetValues);
  }

  public List<string> GetLabels(GradeResult response) {
    return ChartDefaults.GetChartLabels([.. response.Legs.Select(p => p.Id)], true);
  }

  public List<double?> GetValues(Runner runner) {
    if (!runner.StartTime.HasValue) {
      return null;
    }

    var splits = runner.Splits.Select(p => {
      if (!p.ActualTime.HasValue) {
        return (double?)null;
      }

      return (p.ActualTime.Value - p.ActualTime.Value.Date).TotalSeconds;
    }).ToList();

    var start = (runner.StartTime.Value - runner.StartTime.Value.Date).TotalSeconds;

    splits.Insert(0, start);

    return splits;
  }
}