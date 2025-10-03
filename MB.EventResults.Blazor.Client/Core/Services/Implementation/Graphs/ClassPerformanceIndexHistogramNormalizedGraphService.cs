namespace MB.EventResults.Blazor.Client;

public class ClassPerformanceIndexHistogramNormalizedGraphService : IClassPerformanceIndexHistogramNormalizedGraphService {
  public const string Label = "Class Performance Index (Histogram) (Normalized)";

  public string ChartType => "line";

  public string OptionType => "PerformanceHistogram";

  public List<DataSerie<int>> GetDataSeries(GradeResult response) {
    return [DatasetHelper.MergeSeries(DatasetHelper.BuildSeries(response, GetValues))];
  }

  public List<string> GetLabels(GradeResult response) {
    List<string> chartLabels = [];

    for (var j = 0; j <= (200 / ChartDefaults.HistogramStep); j++) {
      chartLabels.Add((j * ChartDefaults.HistogramStep).ToString() + '%');
    }

    return chartLabels;
  }

  public List<int> GetValues(Runner runner) {
    return GraphHelper.GetValues(runner, p => p.PerformanceIndexAdjusted);
  }
}