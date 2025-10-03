namespace MB.EventResults.Blazor.Client;

public class ClassPerformanceIndexGraphService(IStatsCalculator _StatsCalculator) : IClassPerformanceIndexGraphService {
  public const string Label = "Class Performance Index";

  public string ChartType => "line";

  public string OptionType => "Performance";

  public List<DataSerie<double?>> GetDataSeries(GradeResult response) {
    return DatasetHelper.BuildStatSeries(response, GetValues);
  }

  public List<string> GetLabels(GradeResult response) {
    return ChartDefaults.GetChartLabels([.. response.Legs.Select(p => p.Id)], false);
  }

  public Stat<double?> GetValues(List<Split> splits) {
    var values = splits.Select(p => p.PerformanceIndex.HasValue ? (p.PerformanceIndex.Value * 100).Round(1) : (double?)null).ToList();
    return _StatsCalculator.CalculateStat(values);
  }
}