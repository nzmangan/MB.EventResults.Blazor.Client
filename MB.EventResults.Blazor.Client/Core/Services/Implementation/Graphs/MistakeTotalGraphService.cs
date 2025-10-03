namespace MB.EventResults.Blazor.Client;

public class MistakeTotalGraphService : IMistakeTotalGraphService {
  public const string Label = "Mistakes (Total)";

  public string ChartType => "bar";

  public string OptionType => "Mistakes";
  public List<DataSerie<double>> GetDataSeries(GradeResult response) {
    return DatasetHelper.BuildSeries(response, GetValues);
  }

  public List<string> GetLabels(GradeResult response) {
    return ["Total"];
  }

  public List<double> GetValues(Runner runner) {
    return [
      runner.Splits.Sum(p => p.TimeLoss ?? 0)
    ];
  }
}