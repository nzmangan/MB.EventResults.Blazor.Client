namespace MB.EventResults.Blazor.Client;

public class PerformanceIndexNormalizedGraphService : IPerformanceIndexNormalizedGraphService {
  public const string Label = "Performance Index (Normalized)";

  public string ChartType => "line";

  public string OptionType => "Performance";

  public List<DataSerie<double?>> GetDataSeries(GradeResult response) {
    return DatasetHelper.BuildSeries(response, GetValues);
  }

  public List<string> GetLabels(GradeResult response) {
    return ChartDefaults.GetChartLabels([.. response.Legs.Select(p => p.Id)], false);
  }

  public List<double?> GetValues(Runner runner) {
    return [.. runner.Splits.Select(p => p.PerformanceIndexAdjusted.HasValue ? (p.PerformanceIndexAdjusted.Value * 100).Round(1) : (double?)null)];
  }
}