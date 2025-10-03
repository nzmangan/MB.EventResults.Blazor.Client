namespace MB.EventResults.Blazor.Client;

public static class GraphHelper {
  public static List<int> GetValues(Runner runner, Func<Split, double?> valueSelector) {
    List<int> items = [];

    for (var i = 0; i < ChartDefaults.HistogramMax / ChartDefaults.HistogramStep; i++) {
      items.Add(0);
    }

    for (var i = 0; i < runner.Splits.Count; i++) {
      var value = valueSelector(runner.Splits[i]);
      if (value.HasValue) {
        for (var s = 0; s < 200 / ChartDefaults.HistogramStep; s++) {
          var boundry = ((s + 1) * ChartDefaults.HistogramStep) - (ChartDefaults.HistogramStep / 2);

          if ((value * 100) < boundry) {
            items[s] = items[s] + 1;
            break;
          }
        }
      }
    }

    return items;
  }
}