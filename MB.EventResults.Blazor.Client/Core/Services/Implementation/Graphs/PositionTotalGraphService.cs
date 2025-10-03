namespace MB.EventResults.Blazor.Client;

public class PositionTotalGraphService : IPositionTotalGraphService {
  public const string Label = "Position (Total)";

  public string ChartType => "line";

  public string OptionType => "Position";

  public List<DataSerie<int?>> GetDataSeries(GradeResult response) {
    return DatasetHelper.BuildSeries(response, GetValues);
  }

  public List<string> GetLabels(GradeResult response) {
    return ChartDefaults.GetChartLabels([.. response.Legs.Select(p => p.Id)], false);
  }

  public List<int?> GetValues(Runner runner) {
    return [.. runner.Splits.Select(p => p.TotalPosition)];
  }
}