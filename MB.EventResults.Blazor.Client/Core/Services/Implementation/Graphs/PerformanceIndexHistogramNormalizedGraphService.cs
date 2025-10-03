namespace MB.EventResults.Blazor.Client;

public class PerformanceIndexHistogramNormalizedGraphService : IPerformanceIndexHistogramNormalizedGraphService {
  public const string Label = "Performance Index (Histogram) (Normalized)";

  public string ChartType => "line";

  public string OptionType => "PerformanceHistogram";

  public List<DataSerie<int>> GetDataSeries(GradeResult response) {
    return DatasetHelper.BuildSeries(response, GetValues);
  }

  public List<string> GetLabels(GradeResult response) {
    List<string> chartLabels = [];

    for (var j = 0; j <= (200 / ChartDefaults.HistogramStep); j++) {
      chartLabels.Add((j * ChartDefaults.HistogramStep).ToString() + '%');
    }

    return chartLabels;
  }

  public List<int> GetValues(Runner runner) {
    var step = 5;
    List<int> items = [];

    for (var i = 0; i < 200 / step; i++) {
      items.Add(0);
    }

    for (var i = 0; i < runner.Splits.Count; i++) {
      if (runner.Splits[i].PerformanceIndexAdjusted.HasValue) {
        for (var s = 0; s < 200 / step; s++) {
          var boundry = ((s + 1) * step) - (step / 2);

          if ((runner.Splits[i].PerformanceIndexAdjusted * 100) < boundry) {
            items[s] = items[s] + 1;
            break;
          }
        }
      }
    }

    return items;
  }
}