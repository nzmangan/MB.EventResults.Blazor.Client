namespace MB.EventResults.Blazor.Client;

public static class DatasetHelper {
  public static List<DataSerie<T>> BuildSeries<T>(GradeResult response, Func<Runner, List<T>> func) {
    return [.. Enumerable.Range(0, response.Runners.Count).Select(i =>
      new DataSerie<T> {
        Label = response.Runners[i].Name,
        Data = func(response.Runners[i]),
        Color = ChartDefaults.Colors[i % ChartDefaults.Colors.Count],
      })];
  }

  public static List<DataSerie<T>> BuildStatSeries<T>(GradeResult response, Func<List<Split>, Stat<T>> func) {
    List<Stat<T>> data = [];

    var items = response?.Runners?[0]?.Splits?.Count ?? 0;

    for (int index = 0; index < items; index++) {
      List<Split> row = [];
      foreach (var runner in response.Runners) {
        row.Add(runner.Splits[index]);
      }
      data.Add(func(row));
    }

    return [new () {
      Label = "Average",
      Data = [..data.Select(p => p.Avarage)],
      Color = ChartDefaults.Colors[0]
    },new () {
      Label = "Max",
      Data = [.. data.Select(p=>p.Max)],
      Color = ChartDefaults.Colors[1]
    },new () {
      Label = "Min",
      Data = [..data.Select(p => p.Min)],
      Color = ChartDefaults.Colors[2]
    },new () {
      Label = "Median",
      Data = [..data.Select(p => p.Median)],
      Color = ChartDefaults.Colors[3]
    },new () {
      Label = "Standard Deviation",
      Data = [.. data.Select(p=>p.StandardDeviation).OfType<T>()],
      Color = ChartDefaults.Colors[4]
    }];
  }

  public static DataSerie<int> MergeSeries(List<DataSerie<int>> list) {
    if (list is null || list.Count < 1) {
      return new();
    }

    var items = list[0].Data.Count;

    List<int> data = [.. Enumerable.Range(0, items).Select(p => 0)];

    for (int i = 0; i < items; i++) {
      data[i] = list.Sum(p => p.Data[i]);
    }

    return new() {
      Label = "Total",
      Data = data,
      Color = ChartDefaults.Colors[0]
    };
  }
}